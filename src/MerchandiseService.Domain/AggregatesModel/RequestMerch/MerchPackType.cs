using System;
using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregatesModel
{
    public class MerchPackType
        : Enumeration
    {
        public static MerchPackType WelcomePack = new(1, nameof(WelcomePack));
        public static MerchPackType StarterPack = new(2, nameof(StarterPack));
        public static MerchPackType ConferenceListenerPack = new(3, nameof(ConferenceListenerPack));
        public static MerchPackType ConferenceSpeakerPack = new(4, nameof(ConferenceSpeakerPack));
        public static MerchPackType VeteranPack = new(5, nameof(VeteranPack));

        public MerchPackType(int id, string name) : base(id, name)
        {
        }
        
        public static IEnumerable<MerchPackType> List() =>
            new[] { WelcomePack, StarterPack, ConferenceListenerPack, ConferenceSpeakerPack, VeteranPack };
        
        public static MerchPackType From(int id)
        {
            var merchPack = List().SingleOrDefault(s => s.Id == id);

            if (merchPack == null)
            {
                throw new ArgumentException($"Possible values for Status: {String.Join(",", List().Select(s => s.Name))}");
            }

            return merchPack;
        }

    }
}