using System;
using KeepCalmAndMIC.Repository;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace KeepCalmAndMIC.BusinessLayer
{
	public class BaseManagement<T> : IDisposable where T : IDisposable
	{
		private UnitOfWork _unitOfWork;

		protected IOwinContext OwinContext { get; set; }
		protected UnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = OwinContext.Get<UnitOfWork>());

		public BaseManagement(IOwinContext owinContext)
		{
			OwinContext = owinContext;
		}

		public static T Create(IdentityFactoryOptions<T> factory, IOwinContext context)
		{
			return (T)Activator.CreateInstance(typeof(T), context);
		}

		public void Dispose()
		{
		}
	}
}