using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using ED_2_LAB4__3.Models;

namespace ED_2_LAB4__3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // POST: api/LZW
        [Route("Compresionlzw")]
        [HttpPost]
        public void PostCompresionLZW([FromForm] IFormFile Nombre)
        {
            LZW LZW = new LZW();
            var arch = Path.GetFullPath(Nombre.FileName);
            var arch1 = new FileStream(arch, FileMode.Open);
            LZW.dictionary_initial(arch1);
            LZW.compression_process(arch1, arch);

        }
        [Route("Descompresionlzw")]
        [HttpPost]
        public void DescomprimirLZW([FromForm] IFormFile Nombre)
        {
            LZW LZW = new LZW();
            var arch = Path.GetFullPath(Nombre.FileName);
            var arch1 = new FileStream(arch, FileMode.Open);
            LZW.descompression(Nombre.FileName);
        }
        // TUVIMOS PROBLEMAS PARA MANEJAR ARCHIVOS CON HUFFMAN
        //[Route("CompresionlHuffman")]
        //[HttpPost]
        //public void CompresionHuffman([FromForm] IFormFile Nombre)
        //{
        //    Huffman_A Huffman = new Huffman_A();
        //    Huffman_A objComprimir = new Huffman_A();
        //    var arch = Path.GetFullPath(Nombre.FileName);
        //    var arch1 = new FileStream(arch, FileMode.Open);
        //    objComprimir.LeerArchivo(arch1);

        //}
        //[Route("DescompresionlHuffman")]
        //[HttpPost]
        //public void DescompresionHuffman([FromForm] IFormFile Nombre)
        //{
        //    Huffman_A Huffman = new Huffman_A();
        //    var arch = Path.GetFullPath(Nombre.FileName);
        //    var arch1 = new FileStream(arch, FileMode.Open);


        //}
    }
}
