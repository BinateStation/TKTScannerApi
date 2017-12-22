using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiApp.Models;

namespace WebApiApp.Layour
{
    public class DbConnect
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnection"].ToString());
        
        public TicketDetails getTicketDetail(string qrcode)
        {
            TicketDetails ticketDetails = new TicketDetails();
            try
            {
                SqlCommand cmd = new SqlCommand("getTicketDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("", "");
                con.Open();            
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 )
                {
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                       
                    }
                }
                return ticketDetails;
            }
            catch (Exception ex)
            {

                return ticketDetails;
            }
            finally
            {
                con.Close();
            }
            
        }

        internal Payments updatePayment(int ticket_id, int amount, int collecterId)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("updatePayment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ticket_id", ticket_id);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@collecterId", collecterId);
                cmd.Parameters.AddWithValue("@mode", null);
                cmd.Parameters.AddWithValue("@remark", null);
                con.Open();
                Payments payments = new Payments();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        payments.status = true;
                        payments.payment.amount = dRow["AmountCollected"] != DBNull.Value ? Convert.ToInt32(dRow["AmountCollected"].ToString()) : 0;
                        payments.payment.id = dRow["TKTSL"] != DBNull.Value ? Convert.ToInt32(dRow["TKTSL"].ToString()) : 0;
                        payments.payment.date = dRow["EntryDateTime"] != DBNull.Value ? Convert.ToInt32(dRow["EntryDateTime"].ToString()) : 0;
                        payments.payment.status = dRow["Mode"] != DBNull.Value ? dRow["Mode"].ToString() : "";
                    }
                }
                return payments;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        internal PaxDetails addEditPax(int ticket_id, int pax_id, string name, string mobile, DateTime dob, string anniversary, string email)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("addEditPax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ticket_id", ticket_id);
                cmd.Parameters.AddWithValue("@pax_id", pax_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@anniversary", anniversary);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                PaxDetails paxDetails = new PaxDetails();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        paxDetails.status = true;
                        paxDetails.pax.anniversary = dRow["anniversary"] != DBNull.Value ? Convert.ToInt32(dRow["anniversary"].ToString()) : 0;
                        paxDetails.pax.id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"].ToString()) : 0;
                        paxDetails.pax.dob = dRow["dob"] != DBNull.Value ? Convert.ToInt32(dRow["dob"].ToString()) : 0;
                        paxDetails.pax.email = dRow["email"] != DBNull.Value ? dRow["email"].ToString() : "";
                        paxDetails.pax.name = dRow["name"] != DBNull.Value ? dRow["name"].ToString() : "";
                        paxDetails.pax.mobile = dRow["mobile"] != DBNull.Value ? dRow["mobile"].ToString() : "";
                 
                    }
                }
                return paxDetails;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        internal RemovePax removePax(int ticket_id, int pax_id)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("removePax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ticket_id", ticket_id);
                cmd.Parameters.AddWithValue("@pax_id", pax_id);
                con.Open();
                RemovePax removePax = new RemovePax();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        removePax.status = true;
                        removePax.pax.anniversary = dRow["anniversary"] != DBNull.Value ? Convert.ToInt32(dRow["anniversary"].ToString()) : 0;
                        removePax.pax.id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"].ToString()) : 0;
                        removePax.pax.dob = dRow["dob"] != DBNull.Value ? Convert.ToInt32(dRow["dob"].ToString()) : 0;
                        removePax.pax.email = dRow["email"] != DBNull.Value ? dRow["email"].ToString() : "";
                        removePax.pax.name = dRow["name"] != DBNull.Value ? dRow["name"].ToString() : "";
                        removePax.pax.mobile = dRow["mobile"] != DBNull.Value ? dRow["mobile"].ToString() : "";
                 

                    }
                }
                return removePax;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        internal ChechInDetails checkIn(int ticket_id)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("getChechInDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ticket_id", ticket_id);
                con.Open();
                ChechInDetails chechInDetails = new ChechInDetails();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        chechInDetails.status = true;
                        chechInDetails.check_in_log.type = dRow["type"] != DBNull.Value ? dRow["type"].ToString() : "";
                        chechInDetails.check_in_log.id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"].ToString()) : 0;
                        chechInDetails.check_in_log.date = dRow["date"] != DBNull.Value ? Convert.ToInt32(dRow["date"].ToString()) : 0;
                       
                    }
                }
                return chechInDetails;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
    
}