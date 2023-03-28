using AutoMapper;
using CashRegister.Domain.Dto;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public BillController(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
        [HttpGet("getAll")]
        public IActionResult GetAllBills()
        {
            var listOfBills = _billRepository.GetAllBills();
            return listOfBills != null ? Ok(listOfBills) : BadRequest();
        }


        [HttpGet("{billNumber}")]
        public IActionResult GetBillByBillNumber(string billNumber)
        {
            var bill = _billRepository.GetBillByBillNumber(billNumber: billNumber);
            return bill == null ? NotFound($" Bill with number: {billNumber} not found.") : Ok(bill);
        }

        [HttpPost()]
        public IActionResult AddNewBill(Bill bill)
        {
            var newBill = _billRepository.CreateNewBull(bill: bill);
            return newBill ? Ok(newBill) : BadRequest("Somethign went wrong.");    
        }

        [HttpPut("{billNumber}")]
        public IActionResult EditBill(string billNumber, [FromBody] BillDto billDto)
        {
            if (!_billRepository.CheckIfBillExists(billNumber: billNumber))
                return NotFound($"Bill with number: {billNumber} does not exist.");

            if (!ModelState.IsValid)
                return BadRequest();

            var mappedBill = _mapper.Map<Bill>(billDto);
            var updateBill = _billRepository.UpdateBill(bill: mappedBill);
            return updateBill ? Ok(updateBill) : BadRequest();
        }

        //[HttpDelete("{billNumber}")]
        //public IActionResult DeleteBill(string billNumber) 
        //{
        //    if (!_billRepository.CheckIfBillExists(billNumber)) return NotFound($"Bill with number: {billNumber} does not exist.");
        //    var bill = _billRepository.GetBillByBillNumber(billNumber);
        //    var deleteBill = _billRepository.DeleteBill(bill);
        //    return deleteBill ? Ok(deleteBill) : BadRequest();
        //}

    }
}
