﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegulatedNoise.EDDB_Data.CommoditiesJsonTypes;

namespace RegulatedNoise.EDDB_Data
{

    public class EDStation
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        string m_MaxLandingPadSize;
        [JsonProperty("max_landing_pad_size")]
        public string MaxLandingPadSize { get{return m_MaxLandingPadSize;} set{m_MaxLandingPadSize = value; if(m_MaxLandingPadSize == null) m_MaxLandingPadSize = string.Empty;} }

        private int? m_DistanceToStar;
        [JsonProperty("distance_to_star")]
        public int? DistanceToStar { get{return m_DistanceToStar;} set{m_DistanceToStar = value; if(m_DistanceToStar == null) m_DistanceToStar = -1;} }

        private string m_Faction;
        [JsonProperty("faction")]
        public string Faction { get{return m_Faction;} set{m_Faction = value; if(m_Faction == null) m_Faction = string.Empty;} }

        private string m_Government;
        [JsonProperty("government")]
        public string Government { get{return m_Government;} set{m_Government = value; if(m_Government == null) m_Government = string.Empty;} }

        private string m_Allegiance;
        [JsonProperty("allegiance")]
        public string Allegiance { get{return m_Allegiance;} set{m_Allegiance = value; if(m_Allegiance == null) m_Allegiance = string.Empty;} }

        private string m_State;
        [JsonProperty("state")]
        public string State { get{return m_State;} set{m_State = value; if(m_State == null) m_State = string.Empty;} }

        private string m_Type;
        [JsonProperty("type")]
        public string Type { get{return m_Type;} set{m_Type = value; if(m_Type == null) m_Type = string.Empty;} }

        private int? m_HasBlackmarket;
        [JsonProperty("has_blackmarket")]
        public int? HasBlackmarket { get{return m_HasBlackmarket;} set{m_HasBlackmarket = value; if(m_HasBlackmarket == null) m_HasBlackmarket = -1;} }

        private int? m_HasCommodities;
        [JsonProperty("has_commodities")]
        public int? HasCommodities { get{return m_HasCommodities;} set{m_HasCommodities = value; if(m_HasCommodities == null) m_HasCommodities = -1;} }

        private int? m_HasRefuel;
        [JsonProperty("has_refuel")]
        public int? HasRefuel { get{return m_HasRefuel;} set{m_HasRefuel = value; if(m_HasRefuel == null) m_HasRefuel = -1;} }

        private int? m_HasRepair;
        [JsonProperty("has_repair")]
        public int? HasRepair { get{return m_HasRepair;} set{m_HasRepair = value; if(m_HasRepair == null) m_HasRepair = -1;} }

        private int? m_HasRearm;
        [JsonProperty("has_rearm")]
        public int? HasRearm { get{return m_HasRearm;} set{m_HasRearm = value; if(m_HasRearm == null) m_HasRearm = -1;} }

        private int? m_HasOutfitting;
        [JsonProperty("has_outfitting")]
        public int? HasOutfitting { get{return m_HasOutfitting;} set{m_HasOutfitting = value; if(m_HasOutfitting == null) m_HasOutfitting = -1;} }

        private int? m_HasShipyard;
        [JsonProperty("has_shipyard")]
        public int? HasShipyard { get{return m_HasShipyard;} set{m_HasShipyard = value; if(m_HasShipyard == null) m_HasShipyard = -1;} }

        private string[] m_ImportCommodities;
        [JsonProperty("import_commodities")]
        public string[] ImportCommodities { get{return m_ImportCommodities;} set{m_ImportCommodities = value; if(m_ImportCommodities == null) m_ImportCommodities = new string[0];} }

        private string[] m_ExportCommodities;
        [JsonProperty("export_commodities")]
        public string[] ExportCommodities { get{return m_ExportCommodities;} set{m_ExportCommodities = value; if(m_ExportCommodities == null) m_ExportCommodities = new string[0];} }

        private string[] m_ProhibitedCommodities;
        [JsonProperty("prohibited_commodities")]
        public string[] ProhibitedCommodities { get{return m_ProhibitedCommodities;} set{m_ProhibitedCommodities = value; if(m_ProhibitedCommodities == null) m_ProhibitedCommodities = new string[0];} }

        private string[] m_Economies;
        [JsonProperty("economies")]
        public string[] Economies { get{return m_Economies;} set{m_Economies = value; if(m_Economies == null) m_Economies = new string[0];} }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        private Listing[] m_Listings;
        [JsonProperty("listings")]
        public Listing[] Listings { get{return m_Listings;} set{m_Listings = value; if(m_Listings == null) m_Listings = new Listing[0];} }

         /// <summary>
         /// creates a new station 
         /// </summary>
        public EDStation(){}

        /// <summary>
         /// creates a new station as a copy of another station
         /// only Id and SystemID must declared extra
         /// </summary>
         /// <param name="newId"></param>
         /// <param name="sourceSystemID"></param>
         /// <param name="sourceStation"></param>
        public EDStation(int newId, int sourceSystemID, EDStation sourceStation)
        {
            Id              = newId;
            SystemId        = sourceSystemID;
            getValues(sourceStation);   
        }

        /// <summary>
        /// true, if all data *except the two IDs* is equal (case insensitive)
        /// </summary>
        /// <param name="eqSystem"></param>
        /// <returns></returns>
        public bool EqualsED(EDStation eqStation)
        {
            bool retValue = false;

            if ((Name.Equals(eqStation.Name, StringComparison.InvariantCultureIgnoreCase)) && 
                (MaxLandingPadSize.Equals(eqStation.MaxLandingPadSize)) && 
                (DistanceToStar.Equals(eqStation.DistanceToStar)) && 
                (Faction.Equals(eqStation.Faction, StringComparison.InvariantCultureIgnoreCase)) && 
                (Government.Equals(eqStation.Government, StringComparison.InvariantCultureIgnoreCase)) && 
                (Allegiance.Equals(eqStation.Allegiance, StringComparison.InvariantCultureIgnoreCase)) && 
                (State.Equals(eqStation.State, StringComparison.InvariantCultureIgnoreCase)) && 
                (Type.Equals(eqStation.Type, StringComparison.InvariantCultureIgnoreCase)) && 
                (HasBlackmarket.Equals(eqStation.HasBlackmarket)) && 
                (HasCommodities.Equals(eqStation.HasCommodities)) && 
                (HasRefuel.Equals(eqStation.HasRefuel)) &&
                (HasRepair.Equals(eqStation.HasRepair)) && 
                (HasRearm.Equals(eqStation.HasRearm)) && 
                (HasOutfitting.Equals(eqStation.HasOutfitting)) &&
                (HasShipyard.Equals(eqStation.HasShipyard)))
                    retValue = true;

            if (ImportCommodities.GetUpperBound(0) != eqStation.ImportCommodities.GetUpperBound(0))
            {
                retValue = false;
            } 

            if (ExportCommodities.GetUpperBound(0) != eqStation.ExportCommodities.GetUpperBound(0))
            {
                retValue = false;
            } 

            if (ProhibitedCommodities.GetUpperBound(0) != eqStation.ProhibitedCommodities.GetUpperBound(0))
            {
                retValue = false;
            } 

            if (Economies.GetUpperBound(0) != eqStation.Economies.GetUpperBound(0))
            {
                retValue = false;
            } 

            if (retValue)
                for (int i = 0; i < ImportCommodities.GetUpperBound(0); i++)
                    if (!ImportCommodities[i].Equals(eqStation.ImportCommodities[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        retValue = false;
                        break; 
                    } 

            if (retValue)
                for (int i = 0; i < ExportCommodities.GetUpperBound(0); i++)
                    if (!ExportCommodities[i].Equals(eqStation.ExportCommodities[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        retValue = false;
                        break; 
                    } 
            
            if (retValue)
                for (int i = 0; i < ProhibitedCommodities.GetUpperBound(0); i++)
                    if (!ProhibitedCommodities[i].Equals(eqStation.ProhibitedCommodities[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        retValue = false;
                        break; 
                    } 
            
            if (retValue)
                for (int i = 0; i < Economies.GetUpperBound(0); i++)
                    if (!Economies[i].Equals(eqStation.Economies[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        retValue = false;
                        break; 
                    } 
            
            return retValue;             
        }

        /// <summary>
        /// copy the values from another station exept for the ID
        /// </summary>
        /// <param name="ValueStation"></param>
        public void getValues(EDStation ValueStation)
        {
            Name                  = ValueStation.Name;
            MaxLandingPadSize     = ValueStation.MaxLandingPadSize;
            DistanceToStar        = ValueStation.DistanceToStar;
            Faction               = ValueStation.Faction;
            Government            = ValueStation.Government;
            Allegiance            = ValueStation.Allegiance;
            State                 = ValueStation.State;
            Type                  = ValueStation.Type;
            HasBlackmarket        = ValueStation.HasBlackmarket;
            HasCommodities        = ValueStation.HasCommodities;
            HasRefuel             = ValueStation.HasRefuel;
            HasRepair             = ValueStation.HasRepair;
            HasRearm              = ValueStation.HasRearm;
            HasOutfitting         = ValueStation.HasOutfitting;
            HasShipyard           = ValueStation.HasShipyard;

            ImportCommodities     = (string[])ValueStation.ImportCommodities.Clone();
            ExportCommodities     = (string[])ValueStation.ExportCommodities.Clone();
            ProhibitedCommodities = (string[])ValueStation.ProhibitedCommodities.Clone();
            Economies             = (string[])ValueStation.Economies.Clone();

        }
    }

}
