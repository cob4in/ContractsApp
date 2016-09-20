using Autofac;
using ContractsApp.BusinessLogic;
using ContractsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ContractsApp.Controllers.API
{
    [RoutePrefix("api")]
    public class DataApiController : ApiController
    {
        private IContractRepository _contractRepository;
        private IMinSalaryEntryRepository _minSalariesEntriesRepository;

        public DataApiController(IContractRepository repository, IMinSalaryEntryRepository minSalariesEntriesRepository)
        {
            _contractRepository = repository;
            _minSalariesEntriesRepository = minSalariesEntriesRepository;
        }

        [HttpGet]
        [Route("contracts")]
        public HttpResponseMessage GetContracts(HttpRequestMessage request)
        {
            var contracts = _contractRepository.FindAll();

            return request.CreateResponse<Contract[]>(HttpStatusCode.OK, contracts.ToArray());
        }

        [HttpGet]
        [Route("contract/{contractId}")]
        public HttpResponseMessage GetContract(HttpRequestMessage request, int contractId)
        {
            var contracts = _contractRepository.FindAll();
            var contract = contracts.FirstOrDefault(item => item.ContractId == contractId);

            return request.CreateResponse<Contract>(HttpStatusCode.OK, contract);
        }

        [HttpPost]
        [Route("contract/create")]
        public IHttpActionResult AddContract([FromBody]Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _contractRepository.Insert(contract);
                return Created($"contract/show/{contract.ContractId}", new { newContractId = contract.ContractId });
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("contract/validateName")]
        public IHttpActionResult ValidateContractName([FromBody]string contractName)
        {
            if(string.IsNullOrEmpty(contractName))
            {
                return BadRequest();
            }

            return Ok(new { contactNameTaken = _contractRepository.ContractNameOccurences(contractName) > 0});
        }

        [HttpPost]
        [Route("contract/calculateSalary")]
        public IHttpActionResult CalculateSalary([FromBody]ContractMinData minData)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(new { salary = SalaryStrategyProvider.GetSalaryStrategy(minData.Position, _minSalariesEntriesRepository).CalculateSalary(minData) });
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }
    }
}