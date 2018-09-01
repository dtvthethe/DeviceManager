using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Models.ViewModels
{
    public class ViewModelBase
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Tên không được để trống!")]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}