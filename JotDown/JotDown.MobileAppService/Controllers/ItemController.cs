﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;

using JotDown.MobileAppService.DataObjects;
using JotDown.MobileAppService.Models;

namespace JotDown.MobileAppService.Controllers
{
    // TODO: Uncomment [Authorize] attribute to require user be authenticated to access Item(s).
    [Authorize]
    public class ItemController : TableController<Item>
    {
        protected override void Initialize( HttpControllerContext controllerContext )
        {
            base.Initialize( controllerContext );
            MasterDetailContext context = new MasterDetailContext();
            DomainManager = new EntityDomainManager<Item>( context, Request );
        }

        // GET tables/Item
        public IQueryable<Item> GetAllItems()
        {
            //var user = RequestContext.Principal.Identity.Name;
            ClaimsPrincipal claimsUser = (ClaimsPrincipal) this.User;
            string id = claimsUser.FindFirst( ClaimTypes.NameIdentifier ).Value;
            return Query().Where(i=>i.Account.Equals(id));
        }

        // GET tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Item> GetItem( string id )
        {
            return Lookup( id );
        }

        // PATCH tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Item> PatchItem( string id, Delta<Item> patch )
        {
            return UpdateAsync( id, patch );
        }

        // POST tables/Item
        public async Task<IHttpActionResult> PostItem( Item item )
        {
            Item current = await InsertAsync( item );
            return CreatedAtRoute( "Tables", new { id = current.Id }, current );
        }

        // DELETE tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteItem( string id )
        {
            return DeleteAsync( id );
        }
    }
}