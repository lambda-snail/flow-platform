﻿using AutoMapper;
using Flow.Core.DomainModels;
using Flow.Core.Mediate.UserQuery;
using FlowUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FlowUI.Pages
{
    public partial class UserDetailsInputForm
    {
        [Inject]
        public IMediator _mediator { get; set; }
        [Inject]
        public IMapper _mapper { get; set; }


        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        private UserViewModel LoggedInUser { get; set; } = new UserViewModel();

        public UserDetailsInputForm() { }
        
        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState = await authenticationStateTask;
            string userId = authenticationState.User.FindFirstValue(ClaimTypes.NameIdentifier);
            LoggedInUser = _mapper.Map<UserViewModel>(await _mediator.Send(new GetUserByIdRequest<User> { UserId = Guid.Parse(userId) }));
        }

        protected async Task HandleValidSubmit()
        {

        }

        protected async Task HandleInvalidSubmit()
        {

        }
    }
}
