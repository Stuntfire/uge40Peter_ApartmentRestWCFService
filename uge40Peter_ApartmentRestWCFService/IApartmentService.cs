﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace uge40Peter_ApartmentRestWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IApartmentService
    {
        /// <summary>
        /// Link til Peter's opgaven: https://drive.google.com/open?id=0B5TZmSs3KA0xQzJuMXRJTFF0TTQ
        /// </summary>

        //henter alle apartments i tabellen på databasen
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/")]
        IList<Apartment> GetAllApartment();

        //henter specifik apartment ud fra postnummer
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/postal/{postalcode}")]
        IList<Apartment> GetAllApartmentByPostalCode(string postalcode);

        //henter specifik apartment ud fra by
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/location/{location}")]
        IList<Apartment> GetAllApartmentByLocation(string location);

        //opretter en ny apartment (POST)
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/post/")]
        void CreateApartment(Apartment apartment);

        //sletter en apartment ud fra id
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/delete/{id}")]
        void DeleteApartment(string id);

        //opdaterer en apartment
        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/put/")]
        void UpdateApartment(Apartment apartment);

        ////søg en apartment med/uden opvaske- og vaskemaskine
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/machines/{washingMachine},{dishwasher}")]
        IList<Apartment> SearchMachinesApartment(string washingMachine, string dishwasher);


        //søg en apartment ud fra en min. og maks. pris
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "apartment/price/{minPrice},{maxPrice}")]
        IList<Apartment> SearchPriceApartment(string minPrice, string maxPrice);
    }
}
