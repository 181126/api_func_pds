using Api_Funcionario.DTO;
using Api_Funcionario.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Funcionario.Controllers
{
    [Route("api_funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        List<Funcionario> listaFuncionario = new List<Funcionario>();

        public FuncionarioController()
        {
            var funcionario1 = new Funcionario()
            {
                Id = 1,
                Nome = "Renato",
                CPF = "026.662.922-90",
                CTPS = "32783287325897",
                RG = "1692493",
                Funcao = "Gerente",
                Setor = "Administrativo",
                Sala = "209B",
                Telefone = "(69) 99606-8551",
                UF = "RO",
                Cidade = "Ji-Paraná",
                Bairro = "Araçá",
                Numero = 178,
                CEP = 76906376
            };

            listaFuncionario.Add(funcionario1);
        }
        private bool ValCPF(string CPF)
        {
            CPF = CPF.Replace(".", "");
            CPF = CPF.Replace("-", "");

            if (CPF.Length != 11)
            {
                return false;
            }

            else if(new string(CPF[0], 11) == CPF)
            {
                return false;
            }
            else
            {
                int[] multiplicacoes = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma = 0;

                for (int i = 0; i < CPF.Length; i++)
                {
                    soma += multiplicacoes[i] * i;
                }
                int penultimoDigito = 0;
                if (soma % 11 < 2)
                {
                    penultimoDigito = 0;
                }
                else
                {
                    penultimoDigito = 11 - soma % 11;
                }
                if (penultimoDigito != CPF[9])
                {
                    return false;
                }

                int[] multiplicacoes2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma2 = 0;

                for (int i = 0; i < CPF.Length; i++)
                {
                    soma2 += multiplicacoes2[i] * i;
                }
                int ultimoDigito = 0;
                if (soma2 % 11 < 2)
                {
                    ultimoDigito = 0;
                }
                else
                {
                    ultimoDigito = 11 - soma % 11;
                }
                if (ultimoDigito != CPF[10])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaFuncionario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var funcionario = listaFuncionario.Where(funcDto => funcDto.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }
        [HttpPost]
        public IActionResult Post([FromBody] FuncionarioDTO funcDto)
        {
            if(funcDto == null)
            {
                return BadRequest("Esses Dados São Inválidos");
            }
            var funcionario = new Funcionario();

            funcionario.Nome = funcDto.Nome;
            funcionario.CPF = funcDto.CPF;
            funcionario.CTPS = funcDto.CTPS;
            funcionario.RG = funcDto.RG;
            funcionario.Funcao = funcDto.Setor;
            funcionario.Sala = funcDto.Sala;
            funcionario.Telefone = funcDto.Telefone;
            funcionario.UF = funcDto.UF;
            funcionario.Cidade = funcDto.Cidade;
            funcionario.Bairro = funcDto.Bairro;
            funcionario.Numero = funcDto.Numero;
            funcionario.CEP = funcDto.CEP;

            listaFuncionario.Add(funcionario);

            return StatusCode(StatusCodes.Status201Created, funcionario);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuncionarioDTO funcDto)
        {
            var funcionario = listaFuncionario.Where(funcDto => funcDto.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            funcionario.Nome = funcDto.Nome;
            funcionario.CPF = funcDto.CPF;
            funcionario.CTPS = funcDto.CTPS;
            funcionario.RG = funcDto.RG;
            funcionario.Funcao = funcDto.Funcao;
            funcionario.Setor = funcDto.Setor;
            funcionario.Sala = funcDto.Sala;
            funcionario.Telefone = funcDto.Telefone;
            funcionario.UF = funcDto.UF;
            funcionario.Cidade = funcDto.Cidade;
            funcionario.Bairro = funcDto.Bairro;
            funcionario.Numero = funcDto.Numero;
            funcionario.CEP = funcDto.CEP;

            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var funcionario = listaFuncionario.Where(funcDto => funcDto.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            listaFuncionario.Remove(funcionario);

            return Ok(funcionario);
        }
    }

}
