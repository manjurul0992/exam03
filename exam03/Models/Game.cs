//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace exam03.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Game Name is Required"), StringLength(200), Display(Name = "Game Name")]
        public string GameName { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Prize Money"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Prize { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Playing Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime PlayDate { get; set; }
        public bool Result { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
        [Display(Name = "Category")]
        public int CId { get; set; }
    
        public virtual Category Category { get; set; }
    }
}