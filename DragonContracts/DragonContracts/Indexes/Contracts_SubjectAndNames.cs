using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DragonContracts.Models;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace DragonContracts.Indexes
{
    public class Contracts_SubjectAndNames : AbstractIndexCreationTask<Contract>
    {
        public Contracts_SubjectAndNames()
        {
            Map = contracts => from contract in contracts
                select new
                {
                    Subject = contract.Subject, 
                    FirstParty_Name = contract.FirstParty.Name,
                    SecondParty_Name = contract.SecondParty.Name
                };

            Index(c => c.Subject, FieldIndexing.Analyzed);
            Index(c => c.FirstParty.Name, FieldIndexing.Analyzed);
            Index(c => c.SecondParty.Name, FieldIndexing.Analyzed);
        }
    }
}