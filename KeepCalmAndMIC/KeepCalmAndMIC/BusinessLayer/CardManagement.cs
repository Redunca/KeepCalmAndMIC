using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;

namespace KeepCalmAndMIC.BusinessLayer
{
	public class CardManagement : BaseManagement<CardManagement>
	{
		public CardManagement(IOwinContext owinContext) : base(owinContext) { }
        /*
        public void Exemple()
        {

            UnitOfWork.Cards.GetRandomCards()
        }
        */
	}
}