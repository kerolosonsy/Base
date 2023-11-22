using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApplicationUserAggregate
{
    public class UserGeneratedToken : ParentEntity
    {

        [ForeignKey("User")]
        public string UserId { get; private set; }
        
        public int SourceId { get; private set; }


        public string GeneratedToken { get; private set; }
        public bool IsActive { get; private set; }

        #region virtual props.
        public virtual ApplicationUser User { get; private set; }

        #endregion

        //internal  UserGeneratedToken(UserGeneratedTokenInput input)
        //{
        //    this.Id = input.TokenId;
        //    this.CreationTime = DateTime.Now;
        //    this.GeneratedToken = input.GeneratedToken;
        //    this.IsActive = true;
        //    this.SourceId = input.LoginSource;
        //}

        internal UserGeneratedToken(string tokenId, string token, int loginSource)
        {
            this.Id = tokenId;
            this.CreationTime = DateTime.Now;
            this.GeneratedToken = token;
            this.IsActive = true;
            this.SourceId = loginSource;
        }

        internal void DisableGeneratedToken()
        {
            IsActive = false;
            UpdateTime = DateTime.Now;
        }
    }
}
