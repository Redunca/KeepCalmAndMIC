using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
	public interface IBaseModel : IIdentifiable<int>
	{
		new int Id { get; set; }
		DateTime? CreatedOn { get; set; }
		DateTime? ModifiedOn { get; set; }
	}
}