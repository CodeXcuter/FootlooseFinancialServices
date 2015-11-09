﻿using FootlooseFS.DataPersistence;
using FootlooseFS.Models;
using FootlooseFS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FootlooseFS.EnterpriseService
{
    public class PersonService : IPersonService
    {
        private readonly IFootlooseFSService footlooseService;

        public PersonService()
        {
            footlooseService = new FootlooseFSService(new FootlooseFSSqlUnitOfWorkFactory());
        }

        public PageOfPersonDocuments SearchPersons(int pageNumber, PersonSearchColumn personSearchColumn, SortDirection sortDirection, int numRecordsInPage, Dictionary<PersonSearchColumn, string> criteria)
        {
            var pageOfListPerson = footlooseService.SearchPersonDocuments(pageNumber, personSearchColumn, sortDirection, numRecordsInPage, criteria);

            var pageOfPersons = new PageOfPersonDocuments();
            pageOfPersons.Data = pageOfListPerson.Data;
            pageOfPersons.PageIndex = pageOfListPerson.PageIndex;
            pageOfPersons.PageSize = pageOfListPerson.PageSize;
            pageOfPersons.TotalItemCount = pageOfListPerson.TotalItemCount;

            return pageOfPersons;
        }
    }
}
