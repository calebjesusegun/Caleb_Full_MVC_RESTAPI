using System.Collections.Generic;
using AutoMapper;
using CalebMVCAPI.Data;
using CalebMVCAPI.Dtos;
using CalebMVCAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CalebMVCAPI.Controllers
{

   [Route("/api/calebAPI")]
   [ApiController]
   public class calebAPIController : ControllerBase
   {

      private readonly IcalebAPIRepo _repository;
      private readonly IMapper _mapper;

      public calebAPIController(IcalebAPIRepo repository, IMapper mapper)
      {
         _repository = repository;
         _mapper = mapper;
      }

      //private readonly MockcalebAPIRepo _repository = new MockcalebAPIRepo ();

      //GET api/calebAPI/
      [HttpGet]
      public ActionResult<IEnumerable<calebAPIReadDto>> GetAllCommands()
      {
         var commandItems = _repository.GetAllCommands();

         return Ok(_mapper.Map<IEnumerable<calebAPIReadDto>>(commandItems));
      }

      //GET api/calebAPI/{id}
      [HttpGet("{id}", Name = "GetCommandById")]
      public ActionResult<calebAPIReadDto> GetCommandById(int id)
      {
         var commandItem = _repository.GetCommandById(id);
         if (commandItem != null)
         {
            return Ok(_mapper.Map<calebAPIReadDto>(commandItem));
         }
         return NotFound();
      }

      //POST api/calebAPI/
      [HttpPost]
      public ActionResult<calebAPIReadDto> CreateCommand(calebAPICreateDto calebapiCreateDto)
      {
         var commandModel = _mapper.Map<calebModels>(calebapiCreateDto);
         _repository.CreateCommand(commandModel);
         _repository.SaveChanges();

         var calebapiReadDto = _mapper.Map<calebAPIReadDto>(commandModel);

         return CreatedAtRoute(nameof(GetCommandById), new { Id = calebapiReadDto.Id }, calebapiReadDto);
         //return Ok(calebapiReadDto);
      }

      //PUT api/calebAPI/
      [HttpPut("{id}")]
      public ActionResult UpdateCommand(int id, calebAPIUpdateDto calebapiUpdateDto)
      {
         var commandModelFromRepo = _repository.GetCommandById(id);
         if (commandModelFromRepo == null)
         {
            return NotFound();
         }

         _mapper.Map(calebapiUpdateDto, commandModelFromRepo);

         _repository.UpdateCommand(commandModelFromRepo);

         _repository.SaveChanges();

         return NoContent();
      }

      //PATCH api/calebAPI/
      [HttpPatch("{id}")]
      public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<calebAPIUpdateDto> patchDoc)
      {
         var commandModelFromRepo = _repository.GetCommandById(id);
         if (commandModelFromRepo == null)
         {
            return NotFound();
         }

         var commandToPatch = _mapper.Map<calebAPIUpdateDto>(commandModelFromRepo);
         patchDoc.ApplyTo(commandToPatch, ModelState);

         if (!TryValidateModel(commandToPatch))
         {
            return ValidationProblem(ModelState);
         }

         _mapper.Map(commandToPatch, commandModelFromRepo);

         _repository.UpdateCommand(commandModelFromRepo);

         _repository.SaveChanges();

         return NoContent();

      }

      //DELETE api/calebAPI/{id}
      [HttpDelete("{id}")]
      public ActionResult DeleteCommand(int id)
      {
         var commandModelFromRepo = _repository.GetCommandById(id);
         if (commandModelFromRepo == null)
         {
            return NotFound();
         }

         _repository.DeleteCommand(commandModelFromRepo);

         _repository.SaveChanges();

         return NoContent();
      }
   }
}