﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootlooseFS.DataPersistence;
using FootlooseFS.Models;

namespace FootlooseFS.Service
{
    public interface IFootlooseFSService
    {
        /// <summary>     
        /// SearchPersonDocuments - Return a collection of PersonDocument objects that uses paging   
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="personSearchColumn"></param>
        /// <param name="sortDirection"></param>
        /// <param name="numRecordsInPage"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PageOfList<PersonDocument> SearchPersonDocuments(int pageNumber, PersonSearchColumn personSearchColumn, SortDirection sortDirection, int numRecordsInPage, Dictionary<PersonSearchColumn, string> criteria);

        /// <summary>
        /// GetPersonById - Return the Person entity indentified by the personID
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="personIncludes">What auxilary information should be included with the Person (Address, Account, Phone, Transactions)</param>
        /// <returns></returns>
        Person GetPersonById(int personID, PersonIncludes personIncludes);

        /// <summary>
        /// GetPersonByUsername - Return the Person entity identified by the username
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="personIncludes">What auxilary information should be included with the Person (Address, Account, Phone, Transactions)</param>
        /// <returns></returns>
        Person GetPersonByUsername(string userName, PersonIncludes personIncludes); 

        /// <summary>
        /// InsertPerson - Add a person the the datastore
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        OperationStatus InsertPerson(Person person);

        /// <summary>
        /// UpdatePerson - update a person in the datastore with the encapsulated data in the Person object
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        OperationStatus UpdatePerson(Person person);

        /// <summary>
        /// DeletePerson - remove the person from the datastore
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        OperationStatus DeletePerson(Person person);

        /// <summary>
        /// GetPersonId - Return the personID that identifies the Person with the given username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int GetPersonID(string userName, string password);

        /// <summary>
        /// UpdatePassword - Update the password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        OperationStatus UpdatePassword(string user, string oldPassword, string newPassword);
    }
}
