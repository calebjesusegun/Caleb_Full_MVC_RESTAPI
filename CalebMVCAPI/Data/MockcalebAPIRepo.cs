using System.Collections.Generic;
using CalebMVCAPI.Models;

namespace CalebMVCAPI.Data
{
   public class MockcalebAPIRepo : IcalebAPIRepo
   {
      public void CreateCommand(calebModels cmd)
      {
         throw new System.NotImplementedException();
      }

      public void DeleteCommand(calebModels cmd)
      {
         throw new System.NotImplementedException();
      }

      public IEnumerable<calebModels> GetAllCommands()
      {
         var commands = new List<calebModels>
         {
             new calebModels{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
             new calebModels{Id=1, HowTo="Cut Bread", Line="Get a Knife", Platform="Kettle & Chopping"},
             new calebModels{Id=2, HowTo="Make Tea", Line="Place tea", Platform="Kettle & Cup"}
         };

         return commands;
      }

      public calebModels GetCommandById(int id)
      {
         return new calebModels { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
      }

      public bool SaveChanges()
      {
         throw new System.NotImplementedException();
      }

      public void UpdateCommand(calebModels cmd)
      {
         throw new System.NotImplementedException();
      }
   }
}