//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPVN.App.Web {
    
    
    [global::System.ServiceModel.DomainServices.Hosting.EnableClientAccessAttribute()]
    [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\AuthenticationSe" +
        "rvice.cs", Line=15, Column=4)]
    public class AuthenticationService : global::System.ServiceModel.DomainServices.Server.ApplicationServices.AuthenticationBase<global::SPVN.App.Web.User> {
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\AuthenticationSe" +
            "rvice.cs", Line=15, Column=4)]
        public AuthenticationService() {
        }
    }
    
    [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
        "Service.cs", Line=114, Column=4)]
    public enum CreateUserStatus {
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=116, Column=8)]
        Success,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=117, Column=8)]
        InvalidUserName,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=118, Column=8)]
        InvalidPassword,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=119, Column=8)]
        InvalidQuestion,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=120, Column=8)]
        InvalidAnswer,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=121, Column=8)]
        InvalidEmail,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=122, Column=8)]
        DuplicateUserName,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=123, Column=8)]
        DuplicateEmail,
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=124, Column=8)]
        Failure,
        
    }
    
    [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
        "s", Line=8, Column=4)]
    public sealed class RegistrationData {
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
            "s", Line=8, Column=4)]
        public RegistrationData() {
        }
        
        [global::System.ComponentModel.DataAnnotations.KeyAttribute()]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessageResourceName="ValidationErrorRequiredField", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [global::System.ComponentModel.DataAnnotations.DisplayAttribute(Order=0, Name="UserNameLabel", ResourceType=typeof(global::SPVN.App.Web.Resources.RegistrationDataResources))]
        [global::System.ComponentModel.DataAnnotations.RegularExpressionAttribute("^[a-zA-Z0-9_]*$", ErrorMessageResourceName="ValidationErrorInvalidUserName", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [global::System.ComponentModel.DataAnnotations.StringLengthAttribute(255, MinimumLength=4, ErrorMessageResourceName="ValidationErrorBadUserNameLength", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
            "s", Line=13, Column=8)]
        public string UserName {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
        
        [global::System.ComponentModel.DataAnnotations.KeyAttribute()]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessageResourceName="ValidationErrorRequiredField", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [global::System.ComponentModel.DataAnnotations.DisplayAttribute(Order=2, Name="EmailLabel", ResourceType=typeof(global::SPVN.App.Web.Resources.RegistrationDataResources))]
        [global::System.ComponentModel.DataAnnotations.RegularExpressionAttribute("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4" +
            "}|[0-9]{1,3})(\\]?)$", ErrorMessageResourceName="ValidationErrorInvalidEmail", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
            "s", Line=23, Column=8)]
        public string Email {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
        
        [global::System.ComponentModel.DataAnnotations.DisplayAttribute(Order=1, Name="FriendlyNameLabel", Description="FriendlyNameDescription", ResourceType=typeof(global::SPVN.App.Web.Resources.RegistrationDataResources))]
        [global::System.ComponentModel.DataAnnotations.StringLengthAttribute(255, MinimumLength=0, ErrorMessageResourceName="ValidationErrorBadFriendlyNameLength", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
            "s", Line=33, Column=8)]
        public string FriendlyName {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
        
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessageResourceName="ValidationErrorRequiredField", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [global::System.ComponentModel.DataAnnotations.DisplayAttribute(Order=5, Name="SecurityQuestionLabel", ResourceType=typeof(global::SPVN.App.Web.Resources.RegistrationDataResources))]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
            "s", Line=40, Column=8)]
        public string Question {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
        
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessageResourceName="ValidationErrorRequiredField", ErrorMessageResourceType=typeof(global::SPVN.App.Web.Resources.ValidationErrorResources))]
        [global::System.ComponentModel.DataAnnotations.DisplayAttribute(Order=6, Name="SecurityAnswerLabel", ResourceType=typeof(global::SPVN.App.Web.Resources.RegistrationDataResources))]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\RegistrationData.c" +
            "s", Line=47, Column=8)]
        public string Answer {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
    }
    
    [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\Shared\\User.shared" +
        ".cs", Line=6, Column=4)]
    [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\User.cs", Line=8, Column=4)]
    public partial class User : global::System.ServiceModel.DomainServices.Server.ApplicationServices.UserBase {
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\Shared\\User.shared" +
            ".cs", Line=6, Column=4)]
        public User() {
        }
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\Shared\\User.shared" +
            ".cs", Line=12, Column=8)]
        public string DisplayName {
            get {
                throw new System.NotImplementedException();
            }
        }
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Models\\User.cs", Line=18, Column=8)]
        public string FriendlyName {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
    }
    
    [global::System.ServiceModel.DomainServices.Hosting.EnableClientAccessAttribute()]
    [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
        "Service.cs", Line=15, Column=4)]
    public class UserRegistrationService : global::System.ServiceModel.DomainServices.Server.DomainService {
        
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=15, Column=4)]
        public UserRegistrationService() {
        }
        
        [global::System.ServiceModel.DomainServices.Server.InvokeAttribute(HasSideEffects=true)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=32, Column=8)]
        public global::SPVN.App.Web.CreateUserStatus CreateUser(global::SPVN.App.Web.RegistrationData user, string password) {
            throw new System.NotImplementedException();
        }
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense.SourceInfoAttribute(FileName="C:\\Taller Proyectos 2010-I\\Desarrollo\\SPVN\\SPVN.App.Web\\Services\\UserRegistration" +
            "Service.cs", Line=88, Column=8)]
        public global::System.Collections.Generic.IEnumerable<global::SPVN.App.Web.RegistrationData> GetUsers() {
            throw new System.NotImplementedException();
        }
    }
}
namespace Microsoft.VisualStudio.ServiceModel.DomainServices.Intellisense {
    
    
    [System.AttributeUsageAttribute(System.AttributeTargets.All, AllowMultiple=true)]
    public sealed class SourceInfoAttribute : System.Attribute {
        
        private string _fileName;
        
        private int _line;
        
        private int _column;
        
        public string FileName {
            get {
                return this._fileName;
            }
            set {
                this._fileName = value;
            }
        }
        
        public int Line {
            get {
                return this._line;
            }
            set {
                this._line = value;
            }
        }
        
        public int Column {
            get {
                return this._column;
            }
            set {
                this._column = value;
            }
        }
    }
}
