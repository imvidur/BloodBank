using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagement.Models;

namespace BloodBankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        private static List<BloodBank> _bloodBankEntries = new List<BloodBank>();
        private static int _currentId = 1;

        [HttpPost]
        public IActionResult CreateEntries([FromBody] List<BloodBank> entries)
        {
            if (entries == null || !entries.Any())
            {
                return BadRequest("No valid entries provided.");
            }

            foreach (var entry in entries)
            {
                entry.Id = _currentId++;
                _bloodBankEntries.Add(entry);
            }

            return CreatedAtAction(nameof(GetAllEntries), new { }, entries);
        }


        [HttpGet]

        public IActionResult GetAllEntries() {

            return Ok(_bloodBankEntries);
        }

        [HttpGet("{id}")]

        public IActionResult GetEntryById(int id)
        {

            var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound($"The given entry with id {id} not found!");
            }

            return Ok(entry);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateEntry(int id, [FromBody] BloodBank upentry)
        {
            if (upentry == null || upentry.Id != id) {

                return BadRequest("EIther no data sent or mismatched ID");
            }

            var entry = _bloodBankEntries.FirstOrDefault(entry => entry.Id == id);
            if (entry == null)
            {
                return NotFound($"The given entry with id {id} not found!");

            }

            entry.DonorName = upentry.DonorName;
            entry.Age = upentry.Age;
            entry.BloodType = upentry.BloodType;
            entry.CollectionDate = upentry.CollectionDate;
            entry.ContactInfo = upentry.ContactInfo;
            entry.ExpirationnDate = upentry.ExpirationnDate;
            entry.Status = upentry.Status;

            return NoContent();

        }

        [HttpDelete("{id}")]

        //here no need to pass Frombody as parameter because it deletes simply based on the identifier(id)
        public IActionResult DeleteEntry(int id)
        {

            var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound($"The given entry with id {id} not found!");
            }

            _bloodBankEntries.Remove(entry);
            return NoContent();

        }

        //Pagination- to return paginated list of bloodbank entries 
        [HttpGet("paging")]

        public IActionResult GetPaginatedEntries(int page = 1, int size = 10)
        {
            if (page < 0 || size < 0)
            {
                return BadRequest("Invalid request for pagination made");
            }


            var totalcount = _bloodBankEntries.Count;

            var paginatedentry = _bloodBankEntries.
                Skip((page - 1) * size)
                .Take(size)
                .ToList();

            var response = new
            {

                totalEntries = totalcount,
                Page = page,
                Size = size,
                Paginatedentry = paginatedentry


            };

            return Ok(response);

        }

        //search functionality

        [HttpGet("search/bloodtype")]
        public IActionResult SearchbyBloodType(string bloodType)
        {
            if (string.IsNullOrWhiteSpace(bloodType))
            {
                return BadRequest("Blood type must be provided");
            }
            var result = _bloodBankEntries.Where(e => e.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                return NotFound($"No entries found for this {bloodType} blood type");

            }

            return Ok(result);

        }

        [HttpGet("search/status")]
        public IActionResult SearchbyStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return BadRequest("Status must be provided");
            }

            var result = _bloodBankEntries.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any())
            {
                return NotFound($"No entried found for this specified{status}");

            }
            return Ok(result);
        }

        [HttpGet("search/donorname")]
        public IActionResult SearchbyDonorName(string donorname)
        {
            if (string.IsNullOrWhiteSpace(donorname))
            {
                return BadRequest("Status must be provided");
            }

            var result = _bloodBankEntries.Where(e => e.DonorName.Equals(donorname, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any())
            {
                return NotFound($"No entried found for this specified{donorname}");

            }
            return Ok(result);
        }

        [HttpGet("sort")]
        public IActionResult Sort(string sortBy, string order = "asc")
        {
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return BadRequest("Sort field must be provided.");
            }

            List<BloodBank> sortedList;
            switch (sortBy.ToLower())
            {
                case "bloodtype":
                    sortedList = order.ToLower() == "desc"
                        ? _bloodBankEntries.OrderByDescending(e => e.BloodType).ToList()
                        : _bloodBankEntries.OrderBy(e => e.BloodType).ToList();
                    break;

                case "collectiondate":
                    sortedList = order.ToLower() == "desc"
                        ? _bloodBankEntries.OrderByDescending(e => e.CollectionDate).ToList()
                        : _bloodBankEntries.OrderBy(e => e.CollectionDate).ToList();
                    break;

                default:
                    return BadRequest($"Sorting by {sortBy} is not supported.");
            }

            return Ok(sortedList);
        }

        [HttpGet("filter")]
        public IActionResult Filter(string? bloodType = null, string? status = null)
        {
            var filteredvals = _bloodBankEntries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(bloodType))
            {
                filteredvals = filteredvals.Where(e => e.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                filteredvals = filteredvals.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            var result = filteredvals.ToList();

            if (!result.Any())
            {
                return NotFound("No entries found with the specified filters.");
            }

            return Ok(result);
        }

    }
}
 