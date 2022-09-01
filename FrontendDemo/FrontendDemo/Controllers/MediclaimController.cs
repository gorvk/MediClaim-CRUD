using FrontendDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace FrontendDemo.Controllers
{
    public class MediclaimController : Controller
    {

        string baseURL = "https://localhost:8080/api/mediclaims";
        static readonly HttpClient client = new HttpClient();

        // GET: Mediclaim
        public async Task<ActionResult> Index()
        {
            List<Claim> claimList = new List<Claim>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(baseURL);
                response.EnsureSuccessStatusCode();
                claimList = await response.Content.ReadFromJsonAsync<List<Claim>>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return View(claimList);
        }
        public async Task<ActionResult> Details()
        {
            return View();
        }
        public async Task<ActionResult> Details_ClaimData(int id)
        {
            Claim responseBody;
            List<Claim> claimList = new List<Claim>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(baseURL + "/" + id);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadFromJsonAsync<Claim>();
                claimList.Add(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return View(claimList);
        }


        // POST: Mediclaim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Claim claim)
        {
            try
            {
                JsonSerializerOptions opt = new JsonSerializerOptions() { WriteIndented = true };
                string data = JsonSerializer.Serialize<Claim>(claim, opt);
                HttpContent content = new StringContent(data);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync(baseURL, content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.Write(e);
                return RedirectToAction(nameof(Create));
            }
        }
        public ActionResult Create()
        {
            Claim claim = new Claim();
            return View(claim);
        }

        // GET: Mediclaim/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        public async Task<ActionResult> Edit_ClaimData(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(baseURL+"/"+id);
                response.EnsureSuccessStatusCode();
                Claim claim = await response.Content.ReadFromJsonAsync<Claim>();
                Console.WriteLine(claim);
                return View(claim);
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        public async Task<ActionResult> Edit_SubmitData(Claim claim)
        {
            try
            {
                JsonSerializerOptions opt = new JsonSerializerOptions() { WriteIndented = true};
                string data = JsonSerializer.Serialize<Claim>(claim, opt);
                HttpContent content = new StringContent(data);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PutAsync(baseURL+"/"+claim.Id, content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: Mediclaim/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Mediclaim/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(baseURL+"/"+id);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
