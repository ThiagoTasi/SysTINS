﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;

namespace SysTINSClass
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public Nível Nível { get; set; }
        public bool Ativo { get; set; }

        public Usuario()
        {
            Nível = new();
        }
        public Usuario(string nome, string email, string senha, Nível nível)
        {

            Nome = nome;
            Email = email;
            Senha = senha;
            Nível = nível;
        }

        public Usuario(string nome, string email, string senha, Nível nível, bool ativo)
        {

            Nome = nome;
            Email = email;
            Senha = senha;
            Nível = nível;
            Ativo = ativo;
        }

        public Usuario(int id, string nome, string email, string senha, Nível nível, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Nível = nível;
            Ativo = ativo;

        }
        // inserir usuario
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            //cmd.CommandText = $"insert into usuarios values (0, '{Nome}', '{Email}', md5('{Senha}'),{Nível.Id}, default);";


            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_insert";
            cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnível", Nível);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }
        // ObterPorId 
        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from usuarios where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    Nível.ObterPorId(dr.GetInt32(4)),
                    dr.GetBoolean(5)
                    );
            }
            return usuario;
        }
        public static List<Usuario> ObterLista()
        {
            List<Usuario> lista = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from usuarios order by nome asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    Nível.ObterPorId(dr.GetInt32(4)),
                    dr.GetBoolean(5)
                    )
                );
            }
            return lista;
        }
        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_altera";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnivel", Nível.Id);
            return cmd.ExecuteNonQuery() > 0? true : false;

        }
        // efetuar login
        public static Usuario EfetuarLogin(string email, string senha)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from usarios where email = '{email}' and senha = md5('{senha}') and ativo = 1";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    Nível.ObterPorId(dr.GetInt32(4)),
                    dr.GetBoolean(5)
                    );
            }
            return usuario;
        }
    }
}


//DELIMITER $$
//USE `systinsdb01`$$
//-- drop procedure `sp_usuario_altera`
//CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_altera`(
//-- parâmetros da procedure
//spid int, spnome varchar(60), spsenha varchar(32), spnivel int)
//begin
//	update usuarios 
//	set nome = spnome, senha = md5(spsenha), nivel_id = spnivel where id = spid;
//end$$

//DELIMITER $$
//USE `systinsdb01`$$
//CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_insert`(
//-- parâmetros da procedure
//spnome varchar(60), spemail varchar(60), spsenha varchar(32), spnivel int)
//begin
//	insert into usuarios usuariossp_usuario_insert
//	values (0, spnome, spemail, md5(spsenha), spnivel, default);
//select* from usuarios where id = last_insert_id();
//end$$

//id int(4) AI PK 
//nome varchar(60) 
//email varchar(60) 
//senha varchar(32) 
//nivel_id int(11) 
//ativo bit(1)
