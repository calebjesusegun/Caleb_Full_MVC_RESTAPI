using System.Collections.Generic;
using CalebMVCAPI.Models;

namespace CalebMVCAPI.Data
{
   public interface IcalebAPIRepo
   {
      bool SaveChanges();
      IEnumerable<calebModels> GetAllCommands();
      calebModels GetCommandById(int id);

      void CreateCommand(calebModels cmd);

      void UpdateCommand(calebModels cmd);

      void DeleteCommand(calebModels cmd);
   }
}