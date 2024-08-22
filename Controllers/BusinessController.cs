using Mvc_StoredProcedure_create.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using System.Web;
using System.Web.UI.WebControls;

public class BusinessController : Controller
{
    private BusinessDatabaseEntities15 db = new BusinessDatabaseEntities15();

    // GET: BusinessInformation/Create
    public ActionResult Create()
    {
        ViewBag.Business_Type = new SelectList(new List<string> { "Retail", "Service", "Manufacturing", "Other" });
        ViewBag.Business_Category = new SelectList(new List<string> { "Fashion", "Technology", "Healthcare", "Education", "Other" });
        ViewBag.Business_SubCategory = new SelectList(new List<string> { "Clothing", "Electronics", "Pharmaceuticals", "Training", "Other" });

        return View();
    }

    // POST: BusinessInformation/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,Business_Type,Business_Category,Business_SubCategory,Business_Name,Owner_Name,H_No,Street,Area,Landmark,Pincode,City,State,PAN,GST_Number,CIN,Billing_Address,Billing_Label,Email,Alternate_Email,Mobile_Number,Alternate_Mobile,Authorized_Signature,Description")] BusinessInformation businessInformation, HttpPostedFileBase file)
    {
        if (ModelState.IsValid)
        {
            // Handle file upload
           
            // Using the stored procedure to insert the data
            db.Database.ExecuteSqlCommand(
                "sp_InsertBusiness @Business_Type, @Business_Category, @Business_SubCategory, @Business_Name, @Owner_Name, @H_No, @Street, @Area, @Landmark, @Pincode, @City, @State, @PAN, @GST_Number, @CIN, @Billing_Address, @Billing_Label, @Email, @Alternate_Email, @Mobile_Number, @Alternate_Mobile, @Authorized_Signature, @Description",
                new SqlParameter("@Business_Type", businessInformation.Business_Type),
                new SqlParameter("@Business_Category", businessInformation.Business_Category),
                new SqlParameter("@Business_SubCategory", businessInformation.Business_SubCategory),
                new SqlParameter("@Business_Name", businessInformation.Business_Name),
                new SqlParameter("@Owner_Name", businessInformation.Owner_Name),
                new SqlParameter("@H_No", businessInformation.H_No),
                new SqlParameter("@Street", businessInformation.Street),
                new SqlParameter("@Area", businessInformation.Area),
                new SqlParameter("@Landmark", businessInformation.Landmark),
                new SqlParameter("@Pincode", businessInformation.Pincode),
                new SqlParameter("@City", businessInformation.City),
                new SqlParameter("@State", businessInformation.State),
                new SqlParameter("@PAN", businessInformation.PAN),
                new SqlParameter("@GST_Number", businessInformation.GST_Number),
                new SqlParameter("@CIN", businessInformation.CIN),
                new SqlParameter("@Billing_Address", businessInformation.Billing_Address),
                new SqlParameter("@Billing_Label", businessInformation.Billing_Label),
                new SqlParameter("@Email", businessInformation.Email),
                new SqlParameter("@Alternate_Email", businessInformation.Alternate_Email),
                new SqlParameter("@Mobile_Number", businessInformation.Mobile_Number),
                new SqlParameter("@Alternate_Mobile", businessInformation.Alternate_Mobile),
                new SqlParameter("@Authorized_Signature", businessInformation.Authorized_Signature),
               new SqlParameter("@Description",businessInformation.Description)
               
            );

            return RedirectToAction("Index");
        }

        // Repopulate dropdowns in case of validation errors
        ViewBag.Business_Type = new SelectList(new List<string> { "Retail", "Service", "Manufacturing", "Other" ,"IT","Marketing","Hospital","Networking","Business" }, businessInformation.Business_Type);
        ViewBag.Business_Category = new SelectList(new List<string> { "Fashion", "Technology", "Healthcare", "Education", "Other","Schools","contruction","Teaching","food_Business","Hotels" }, businessInformation.Business_Category);
        ViewBag.Business_SubCategory = new SelectList(new List<string> { "Clothing", "Electronics", "Pharama", "Training", "Other" ,"Ensure","Zebronics","Store"}, businessInformation.Business_SubCategory);

        return View(businessInformation);
    }
}
