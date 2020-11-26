using SistemaCaminhoneiro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaCaminhoneiro.Repositorio
{
    public class CaminhoneiroRepositorio
    {

        private SqlConnection _con;

        private void Connection()
        {

            string connstr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(connstr);
        }
        public List<Motorista> ObterCaminhoneiros()
        {
            Connection();

            List<Motorista> MotoristaLista = new List<Motorista>();

            using (SqlCommand command = new SqlCommand("ObterCaminhoneiros", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MotoristaLista.Add(new Motorista
                    {
                        Cod = Convert.ToInt32(reader["Cod"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Marca = Convert.ToString(reader["Marca"]),
                        Modelo = Convert.ToString(reader["Modelo"]),
                        Placa = Convert.ToString(reader["Placar"]),
                        Eixo = Convert.ToString(reader["Eixo"]),
                        Rua = Convert.ToString(reader["Rua"]),
                        Cep = Convert.ToString(reader["Cep"]),
                        Bairro = Convert.ToString(reader["Bairro"]),
                        Cidade = Convert.ToString(reader["Cidade"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
                    });

                }
                _con.Close();
                return MotoristaLista;
            }
        }
       

        public bool AdicionarCaminhoneiro (Motorista Motor)
        {
            Connection();

            int i;
            using (SqlCommand cmd = new SqlCommand("CadastroCaminhoneiro", _con)) 
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", Motor.Nome);
                cmd.Parameters.AddWithValue("@Marca", Motor.Marca);
                cmd.Parameters.AddWithValue("@Modelo", Motor.Modelo);
                cmd.Parameters.AddWithValue("@Placa", Motor.Placa);
                cmd.Parameters.AddWithValue("@Eixo", Motor.Eixo);
                cmd.Parameters.AddWithValue("@Rua", Motor.Rua);
                cmd.Parameters.AddWithValue("@Cep", Motor.Cep);
                cmd.Parameters.AddWithValue("@Bairro", Motor.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", Motor.Cidade);
                cmd.Parameters.AddWithValue("@Estado", Motor.Estado);

                _con.Open();
                i = cmd.ExecuteNonQuery();

            }

            _con.Close();

            return i >= i;
        }

        public bool AtualizarCaminhoneiro(Motorista Motor)
        {
            Connection();

            int i;
            using (SqlCommand cmd = new SqlCommand("AlterarCaminhoneiro", _con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Motor.Cod);
                cmd.Parameters.AddWithValue("@Nome", Motor.Nome);
                cmd.Parameters.AddWithValue("@Marca", Motor.Marca);
                cmd.Parameters.AddWithValue("@Modelo", Motor.Modelo);
                cmd.Parameters.AddWithValue("@Placa", Motor.Placa);
                cmd.Parameters.AddWithValue("@Eixo", Motor.Eixo);
                cmd.Parameters.AddWithValue("@Rua", Motor.Rua);
                cmd.Parameters.AddWithValue("@Cep", Motor.Cep);
                cmd.Parameters.AddWithValue("@Bairro", Motor.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", Motor.Cidade);
                cmd.Parameters.AddWithValue("@Estado", Motor.Estado);

                _con.Open();
                i = cmd.ExecuteNonQuery();

            }

            _con.Close();

            return i >= i;
        }

        public bool ExcluirCaminhoneiro(int id)
        {
            Connection();

            int i;
            using (SqlCommand cmd = new SqlCommand("ExcluirCaminhoneiroId", _con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);


                _con.Open();
                i = cmd.ExecuteNonQuery();

            }

            _con.Close();

            return i >= i;
        }

    }
}