using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace exam03.Models.GameVM
{
    public class GameVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Game Name is Required"), StringLength(200), Display(Name = "Game Name")]
        public string GameName { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Prize Money"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Prize { get; set; }
        
        public System.DateTime PlayDate { get; set; }
        public bool Result { get; set; }
        [Display(Name ="Picture")]
        public string PicturePath { get; set; }
        [Display(Name = "Category")]
        public int CId { get; set; }
        
        public string CName { get; set; }
        public HttpPostedFileBase Picture { get; set; }
    }
}