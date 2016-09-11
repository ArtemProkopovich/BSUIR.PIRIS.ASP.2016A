using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;

namespace DAL
{
    public class ClientRepository : Repository<Client>
    {
        protected override string InsertQuery { get; } =
            "INSERT INTO Client OUTPUT INSERTED.ID VALUES(@Surname,@Name,@FatherName," +
            "@BirthDate,@Male,@PassportSeries," +
            "@PassportNumber,@Issued,@IssuedDate," +
            "@IdNumber,@BirthPlace,@ResidentialPlace," +
            "@ActualAddress,@HomeNumber,@MobileNumber,@Email," +
            "@Address,@Martial,@Citizenship,@Disability," +
            "@Pencioner,@Income)";

        protected override string UpdateQuery { get; } =
            "UPDATE Client SET Surname = @Surname,Name=@Name,FatherName = @FatherName,BirthDate = @BirthDate,Male = @Male," +
            "PassportSeries = @PassportSeries,PassportNumber =  @PassportNumber," +
            "IssuedBy =  @Issued,IssueDate = @IssuedDate,IdentificationNumber = @IdNumber,BirthPlace =  @BirthPlace," +
            "ResidenceActualPlaceId = @ResidentialPlace,ResidenceActualAddress = @ActualAddress," +
            "HomePhoneNumber = @HomeNumber,MobilePhoneNumber =  @MobileNumber,Email =  @Email,ResidenceAddress =  @Address," +
            "MaritalStatusId = @Martial,CitezenshipId = @Citizenship, DisabilityId = @Disability,Pensioner = @Pencioner," +
            "MonthlyIncome = @Income WHERE Id=@Id";

        protected override string SelectQuery { get; } =
            "SELECT * FROM Client " +
            "JOIN Citizenship ON Citizenship.Id=Client.CitezenshipId " +
            "JOIN Disability ON Disability.Id=Client.DisabilityId " +
            "JOIN MartialStatus ON Client.MaritalStatusId=MartialStatus.Id " +
            "JOIN Town ON Client.ResidenceActualPlaceId=Town.Id WHERE Client.Id = @Id";

        protected override string SelectAllQuery { get; } =
            "SELECT * FROM Client " +
            "JOIN Citizenship ON Citizenship.Id=Client.CitezenshipId " +
            "JOIN Disability ON Disability.Id=Client.DisabilityId " +
            "JOIN MartialStatus ON Client.MaritalStatusId=MartialStatus.Id " +
            "JOIN Town ON Client.ResidenceActualPlaceId=Town.Id";

        protected override string DeleteQuery { get; } = "DELETE FROM Client WHERE Id = @Id";

        public ClientRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override void InitSqlCommandParametres(SqlCommand cmd, Client client)
        {
            cmd.Parameters.AddWithValue("@Surname", client.Surname);
            cmd.Parameters.AddWithValue("@Name", client.Name);
            cmd.Parameters.AddWithValue("@FatherName", client.FatherName);
            cmd.Parameters.AddWithValue("@BirthDate", client.BirthDate);
            cmd.Parameters.AddWithValue("@Male", client.Male);
            cmd.Parameters.AddWithValue("@PassportSeries", client.PassportSeries);
            cmd.Parameters.AddWithValue("@PassportNumber", client.PassportNumber);
            cmd.Parameters.AddWithValue("@Issued", client.IssuedBy);
            cmd.Parameters.AddWithValue("@IssuedDate", client.IssueDate);
            cmd.Parameters.AddWithValue("@IdNumber", client.IdentificationNumber);
            cmd.Parameters.AddWithValue("@BirthPlace", client.BirthPlace);
            cmd.Parameters.AddWithValue("@ResidentialPlace", client.ResidenceActualPlaceId);
            cmd.Parameters.AddWithValue("@ActualAddress", client.ResidenceActualAddress);
            cmd.Parameters.AddWithValue("@HomeNumber", client.HomePhoneNumber);
            cmd.Parameters.AddWithValue("@MobileNumber", client.MobilePhoneNumber);
            cmd.Parameters.AddWithValue("@Email", client.Email);
            cmd.Parameters.AddWithValue("@Address", client.ResidenceAddress);
            cmd.Parameters.AddWithValue("@Martial", client.MaritalStatusId);
            cmd.Parameters.AddWithValue("@Citizenship", client.CitizenshipId);
            cmd.Parameters.AddWithValue("@Disability", client.DisabilityId);
            cmd.Parameters.AddWithValue("@Pencioner", client.Pensioner);
            cmd.Parameters.AddWithValue("@Income", client.MonthlyIncome);
            foreach (IDataParameter pm in cmd.Parameters)
            {
                if (pm.Value == null) pm.Value = DBNull.Value;
            }
        }

        protected override Client GetEntityFromDataRow(DataRow row)
        {
            Client client = new Client();
            client.Id = Convert.ToInt32(row["Id"]);
            client.Surname = row["Surname"] as string;
            client.Name = row["Name"] as string;
            client.FatherName = row["FatherName"] as string;
            client.BirthDate = Convert.ToDateTime(row["BirthDate"]);
            client.BirthPlace = row["BirthPlace"] as string;
            client.CitizenshipId = Convert.ToInt32(row["CitezenshipId"]);
            client.DisabilityId = Convert.ToInt32(row["DisabilityId"]);
            client.Email = row["Email"] as string;
            client.HomePhoneNumber = row["HomePhoneNumber"] as string;
            client.IdentificationNumber = row["IdentificationNumber"] as string;
            client.IssuedBy = row["IssuedBy"] as string;
            client.IssueDate = Convert.ToDateTime(row["IssueDate"]);
            client.Male = Convert.ToBoolean(row["Male"]);
            client.MaritalStatusId = Convert.ToInt32(row["MaritalStatusId"]);
            client.MobilePhoneNumber = row["MobilePhoneNumber"] as string;
            client.MonthlyIncome = Convert.ToDecimal(row["MonthlyIncome"]);
            client.PassportNumber = row["PassportNumber"] as string;
            client.PassportSeries = row["PassportSeries"] as string;
            client.Pensioner = Convert.ToBoolean(row["Pensioner"]);
            client.ResidenceActualAddress = row["ResidenceActualAddress"] as string;
            client.ResidenceActualPlaceId = Convert.ToInt32(row["ResidenceActualPlaceId"]);
            client.ResidenceAddress = row["ResidenceAddress"] as string;
            return client;
        }
    }
}
