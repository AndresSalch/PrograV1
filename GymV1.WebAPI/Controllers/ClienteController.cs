using GymV1.Share.Service;
using GymV1.Share.Model;
using Microsoft.AspNetCore.Mvc;

namespace GYMV1.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		string sqlconnection = "Data Source=68.168.208.58;" +
			"Initial Catalog=Progra5; Persist Security Info=True;" +
			"TrustServerCertificate=True; User ID=PrograV;" +
			"Password=Aqi90h7@9";

		[HttpGet]
		[Route("getClientes")]
		public async Task<ActionResult<List<cCliente>>> getClientes()
		{
			try
			{
				dsCliente mdsCliente = new dsCliente(sqlconnection);
				List<cCliente> mLista = await mdsCliente.getServicelist();
				return Ok(mLista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("getCliente/{identificacion}")]
        public async Task<ActionResult<cCliente>> getCliente(string identificacion)
		{
			try
			{
				dsCliente mdsCli = new dsCliente(sqlconnection);
				cCliente mCliente = await mdsCli.getServiceById(identificacion);
				if (mCliente == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(mCliente);
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("agregarClientes")]

        public async Task<ActionResult<string>> AgregarCli(cCliente cliente)
		{
			try
			{
				dsCliente mdsCli = new dsCliente(sqlconnection);
				if( await mdsCli.addService(cliente) == 1)
				{
					return Ok("Ok");
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		[Route("actualizarClientes")]
		public async Task<ActionResult<string>> ActualizarCli(cCliente cliente)
		{
			try
			{
				dsCliente mdsCli = new dsCliente(sqlconnection);
				if (await mdsCli.updateService(cliente) == 1)
				{
					return Ok("OK");
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		[Route("borrarClientes")]
		public async Task<ActionResult<string>> BorrarCli(cCliente cliente)
		{
			try
			{
				dsCliente mdsCli = new dsCliente(sqlconnection);
				if (await mdsCli.deleteService(cliente) == 1)
				{
					return Ok("OK");
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
