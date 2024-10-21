using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;

namespace SysTINSClass
{
    public class Usuario
    {
        public int Id;
        public string? Nome;
        public string? Email;
        public string? Senha;
        public Nível Nível;
        public bool Ativo;

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
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp-usuario_insert";
            cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value=Nome;
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
    }
}

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
