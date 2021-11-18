using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.ValueObjects;
using MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using Model = MerchandiseService.Infrastructure.Repositories.Models;
using Npgsql;

namespace MerchandiseService.Infrastructure.Stubs
{
    public class RequestMerchRepository : IRequestMerchRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;

        public RequestMerchRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }
        

        public async Task<RequestMerch> CreateAsync(RequestMerch itemToCreate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                INSERT INTO request_merch (id, merch_pack_type, status_id, employee_id, quantity, request_date_time)
                VALUES (@SkuId, @MerchPackTypeId, @StatusId, @EmployeeId, @Quantity, @RequestDateTime);
                ";

            var parameters = new
            {
                SkuId = itemToCreate.Sku.Value,
                MerchPackTypeId = itemToCreate.MerchPackType.Id,
                StatusId = itemToCreate.Status.Id,
                EmployeeId = itemToCreate.Employee.Sku.Value,
                Quantity = itemToCreate.Quantity.Value,
                RequestDateTime = itemToCreate.RequestDateTime
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToCreate);
            return itemToCreate;
        }
        

        public async Task<IReadOnlyList<RequestMerch>> FindByEmployeeSkuAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT request_merch.id, request_merch.quantity, request_merch.request_date_time, request_merch.employee_id,
                       merch_pack_type.id, merch_pack_type.name,
                       status.id, status.name
                FROM request_merch 
                INNER JOIN status on request_merch.status_id = status.id
                INNER JOIN merch_pack_type on merch_pack_type.id = request_merch.merch_pack_type
                WHERE request_merch.employee_id = @SkuId;";
            
            var parameters = new
            {
                SkuId = sku.Value,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var requestMerch = await connection.QueryAsync<
                Model.RequestMerch, Model.MerchType, Model.Status, RequestMerch>(commandDefinition,
                (requestMerch, merchType, status) =>
                
                    new RequestMerch(
                    new Sku(requestMerch.Id),
                    new MerchPack(new MerchPackType(merchType.Id, merchType.Name)),
                    new Employee(requestMerch.EmployeeId),
                    requestMerch.Date,
                    new Quantity(requestMerch.Quantity), 
                    new Status(status.Id, status.Name))
                );
            var result = requestMerch.ToList();
            foreach (var item in result)
            {
                _changeTracker.Track(item);
            }

            return result;
        }
        
        public async Task<RequestMerch> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT request_merch.id, request_merch.quantity, request_merch.request_date_time, request_merch.employee_id,
                       merch_pack_type.id, merch_pack_type.name,
                       status.id, status.name
                FROM request_merch 
                INNER JOIN status on request_merch.status_id = status.id
                INNER JOIN merch_pack_type on merch_pack_type.id = request_merch.merch_pack_type
                WHERE request_merch.id = @SkuId;";
            
            var parameters = new
            {
                SkuId = sku.Value,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var requestMerch = await connection.QueryAsync<
                Model.RequestMerch, Model.MerchType, Model.Status, RequestMerch>(commandDefinition,
                (requestMerch, merchType, status) =>
                
                    new RequestMerch(
                        new Sku(requestMerch.Id),
                        new MerchPack(new MerchPackType(merchType.Id, merchType.Name)),
                        new Employee(requestMerch.EmployeeId),
                        requestMerch.Date,
                        new Quantity(requestMerch.Quantity), 
                        new Status(status.Id, status.Name))
            );
            var result = requestMerch.FirstOrDefault();
            if(result != null)
            {
                _changeTracker.Track(result);
            }

            return result;
        }
    }
}