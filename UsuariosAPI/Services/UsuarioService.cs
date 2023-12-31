﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task CadastraUsuario(CreateUsuarioDto dto)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(dto);

                IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

                /*if (!resultado.Succeeded)
                {
                    throw new ApplicationException("Falha ao cadastrar usuário!");
                }*/
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao cadastrar usuário! " + ex.Message);
            }
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            try
            {

            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            /*if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }*/

            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Usuário não cadastrado! " + ex.Message);
            }
        }
    }
}