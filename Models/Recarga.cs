using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Recarga
    {
        public int Id { get; set; }
        [DisplayName("Monto")]
        public int MontoId { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El número debe contener 10 dígitos")]
        
        [Display(Name = "Teléfono")]
        public double PhoneNumber { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El número debe contener 10 dígitos")]
        
        [Display(Name = "Confirmar Teléfono")]
        [Compare("PhoneNumber", ErrorMessage = "Los números no coinciden.")]
        public double ConfirmPhone { get; set; }
        [DisplayName("Compañía")]
        public int CarrierId { get; set; }
        [DisplayName("Fecha Creación")]
        public DateTime DateCreated { get; set; }
        [DisplayName("Acuse")]
        public string StatusCode { get; set; }
        [DisplayName("Estado")]
        public int StatusId { get; set; }
        [DisplayName("Servicio Web")]
        public int? WebServDescId { get; set; }
        [DisplayName("Usuario")]
        public string UserId { get; set; }
        public string MontoCant { get; set; }
        public bool Ok { get; set; }
        public string ResponseFromCarrier { get; set; }
        public int Intent { get; set; }
        public string RecargaReq { get; set; }
        public string CarrierTempName { get; set; }
        public string WSTempName { get; set; }


        public Monto Monto { get; set; }
        public Carrier Carrier { get; set; }
        public WebServDesc WebServDesc { get; set; }

        public Status Status { get; set; }

       public User User { get; set; }

        
    }
}
/*
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "10", "observacion": "Consulta de saldo *133# vigencia 7 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "15", "observacion": "" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "20", "observacion": "Consulta de saldo *133# vigencia 10 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "30", "observacion": "Consulta de saldo *133# vigencia 15 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "50", "observacion": "Consulta de saldo *133# vigencia 30 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "80", "observacion": "" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "100", "observacion": "Consulta de saldo *133# vigencia 60 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "150", "observacion": "Consulta de saldo *133# vigencia 60 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "200", "observacion": "Consulta de saldo *133# vigencia 60 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "300", "observacion": "Consulta de saldo *133# vigencia 60 días dudas y aclaraciones *264" },
{ "Carrier_ID": "01", "Description": "TELCEL ", "Group": "TAE", "Monto": "500", "observacion": "Consulta de saldo *133# vigencia 60 días dudas y aclaraciones *264" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "10", "observacion": "Consulta de saldo *72536 vigencia 10 días dudas y aclaraciones *611 " },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "20", "observacion": "Consulta de saldo *72536 vigencia 20 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "30", "observacion": "Consulta de saldo *72536 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "40", "observacion": "Consulta de saldo *72536 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "50", "observacion": "Consulta de saldo *72536 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "60", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "70", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "80", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611 " },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "100", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "120", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "140", "observacion": "" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "150", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "200", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611 " },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "250", "observacion": "Consulta de saldo *72536 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "300", "observacion": "Consulta de saldo *72536 vigencia 90 días dudas y aclaraciones *611" },
{ "Carrier_ID": "02", "Description": "MOVISTAR ", "Group": "TAE", "Monto": "500", "observacion": "Consulta de saldo *72536 vigencia 90 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "10", "observacion": "Consulta de saldo 050 vigencia 7 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "20", "observacion": "Consulta de saldo 050 vigencia 7 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "30", "observacion": "Consulta de saldo 050 vigencia 15 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "50", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "100", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "150", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "200", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "300", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "500", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "600", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "800", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "900", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "03", "Description": "UNEFON ", "Group": "TAE", "Monto": "1200", "observacion": "Consulta de saldo 050 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "10", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 1 día. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "20", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 2 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "30", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 3 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "50", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 5 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "70", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 7 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "100", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 10 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "150", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 15 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "200", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 20 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "300", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 30 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "04", "Description": "IUSACELL ", "Group": "TAE", "Monto": "500", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 50 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "10", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 1 día. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "20", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 2 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "30", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 3 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "50", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 5 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "100", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 10 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "150", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 15 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "200", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 20 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "300", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 30 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "05", "Description": "NEXTEL ", "Group": "TAE", "Monto": "500", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 50 días. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "20", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "30", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "40", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "50", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "100", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "150", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "200", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "300", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "06", "Description": "VIRGIN ", "Group": "TAE", "Monto": "500", "observacion": "Para planes y paquetes marcar *188# , en la App de Virgin o visita https://virginmobile.mx" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "10", "observacion": "Consulta de saldo *611 vigencia 7 días dudas y aclaraciones *611 " },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "20", "observacion": "Consulta de saldo *611 vigencia 10 días dudas y aclaraciones *611 " },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "30", "observacion": "Consulta de saldo *611 vigencia 10 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "40", "observacion": "Consulta de saldo *611 vigencia 15 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "50", "observacion": "Consulta de saldo *611 vigencia 20 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "60", "observacion": "Consulta de saldo *611 vigencia 20 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "70", "observacion": "Consulta de saldo *611 vigencia 28 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "80", "observacion": "Consulta de saldo *611 vigencia 28 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "100", "observacion": "Consulta de saldo *611 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "120", "observacion": "Consulta de saldo *611 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "150", "observacion": "Consulta de saldo *611 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "200", "observacion": "Consulta de saldo *611 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "250", "observacion": "Consulta de saldo *611 vigencia 30 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "300", "observacion": "Consulta de saldo *611 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "08", "Description": "Maz Tiempo ", "Group": "TAE", "Monto": "500", "observacion": "Consulta de saldo *611 vigencia 60 días dudas y aclaraciones *611" },
{ "Carrier_ID": "09", "Description": "Tuenti ", "Group": "TAE", "Monto": "50", "observacion": "Consulta de saldo *611 vigencia 20 días dudas y aclaraciones *611" },
{ "Carrier_ID": "09", "Description": "Tuenti ", "Group": "TAE", "Monto": "80", "observacion": "Consulta de saldo *611 vigencia 28 días dudas y aclaraciones *611" },
{ "Carrier_ID": "09", "Description": "Tuenti ", "Group": "TAE", "Monto": "100", "observacion": "Consulta *611 vigencia 30 días" },
{ "Carrier_ID": "09", "Description": "Tuenti ", "Group": "TAE", "Monto": "150", "observacion": "Consulta *611 vigencia 30 días " },
{ "Carrier_ID": "09", "Description": "Tuenti ", "Group": "TAE", "Monto": "250", "observacion": "Consulta *611 vigencia 30 días " },
{ "Carrier_ID": "09", "Description": "Tuenti ", "Group": "TAE", "Monto": "300", "observacion": "Consulta *611 vigencia 30 días " },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "10", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegación ilimitada. Vigencia 1 día. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "20", "observacion": "Llamadas, SMS, WhatsApp y Redes Sociales ilimitadas. Navegación 200MB. Vigencia 1 día. Dudas o aclaraciones *611 ." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "30", "observacion": "Llamadas, SMS, WhatsApp y Redes Sociales ilimitadas. Navegación 300MB. Vigencia 3 días. Dudas o aclaraciones *611 ." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "50", "observacion": "Llamadas, SMS, WhatsApp y Redes Sociales ilimitadas. Navegación 500MB. Vigencia 5 días. Dudas o aclaraciones *611 ." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "70", "observacion": "Llamadas, SMS, WhatsApp, Redes Sociales y navegacion ilimitada. Vigencia 7 dÌas. Dudas o aclaraciones marcando al *611 o al 050." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "100", "observacion": "Llamadas, SMS, WhatsApp y Redes Sociales ilimitadas. Navegación 1.5GB. Vigencia 14 días. Dudas o aclaraciones *611 ." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "150", "observacion": "Llamadas, SMS, WhatsApp y Redes Sociales ilimitadas. Navegación 2.3 GB. Vigencia 25 días. Dudas o aclaraciones *611 ." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "200", "observacion": "Llamadas, SMS, WhatsApp y Redes Sociales ilimitadas. Navegación 2GB. Vigencia 35 días. Dudas o aclaraciones *611 ." },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "300", "observacion": "información de vigencias y promociones en ATT https://www.att.com.mx" },
{ "Carrier_ID": "10", "Description": "AT&T ", "Group": "TAE", "Monto": "500", "observacion": "información de vigencias y promociones en ATT https://www.att.com.mx" },
{ "Carrier_ID": "14", "Description": "MEGACABLE ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 559690 0000" },
{ "Carrier_ID": "15", "Description": "TELMEX ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01 800 123 0000 " },
{ "Carrier_ID": "15", "Description": "TELMEX ", "Group": "SERVICIO", "Monto": "1", "observacion": "" },
{ "Carrier_ID": "16", "Description": "CFE ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01800-888CFET o 071" },
{ "Carrier_ID": "17", "Description": "SKY ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01 55 5169 0000" },
{ "Carrier_ID": "18", "Description": "AXTEL ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01 800 2982130" },
{ "Carrier_ID": "19", "Description": "CABLEMAS ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01800 522 2530 " },
{ "Carrier_ID": "20", "Description": "DISH ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01-55-96-28-3474" },
{ "Carrier_ID": "21", "Description": "Ve/TV ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01 55 5169 0000" },
{ "Carrier_ID": "22", "Description": "TELNOR ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01 800 123 2222 " },
{ "Carrier_ID": "23", "Description": "ARABELA ", "Group": "SERVICIO", "Monto": "0", "observacion": "" },
{ "Carrier_ID": "24", "Description": "MAXCOM ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 019008493733 " },
{ "Carrier_ID": "25", "Description": "Credito Hipotecario INFONAVIT ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01 800 008 3900" },
{ "Carrier_ID": "26", "Description": "TELEVIA ", "Group": "TAE", "Monto": "100", "observacion": "Atención a clientes 555265 8855" },
{ "Carrier_ID": "26", "Description": "TELEVIA ", "Group": "TAE", "Monto": "200", "observacion": "Atención a clientes 555265 8855" },
{ "Carrier_ID": "26", "Description": "TELEVIA ", "Group": "TAE", "Monto": "300", "observacion": "Atención a clientes 555265 8855" },
{ "Carrier_ID": "26", "Description": "TELEVIA ", "Group": "TAE", "Monto": "500", "observacion": "Atención a clientes 555265 8855" },
{ "Carrier_ID": "27", "Description": "Gas ECOGAS ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes 01800 700 0000" },
{ "Carrier_ID": "28", "Description": "GAS NATURAL ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes Atención a clientes 01-800-284-3000" },
{ "Carrier_ID": "29", "Description": "GOBIERNO TESORERIA DEL GDF ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atención a clientes Atención a clientes 55883388" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "100", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "200", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "300", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "400", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "500", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "600", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "700", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "800", "observacion": "Atención a clientes 01800 111 0088" }, {
"Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "900", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1000", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1100", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1200", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1300", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1400", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1500", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1600", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1700", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1800", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "1900", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "30", "Description": "IAVE ", "Group": "TAE", "Monto": "2000", "observacion": "Atención a clientes 01800 111 0088" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "15", "observacion": "" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "20", "observacion": "100MB Navegacion, LLamadas y SMS ilimitados, 200MB redes sociales, vigencia 1 dia" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "30", "observacion": "120MB Navegacion, LLamadas y SMS ilimitados, 300MB redes sociales, vigencia 3 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "50", "observacion": "400MB Navegacion, LLamadas y SMS ilimitados, 500MB redes sociales, vigencia 7 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "80", "observacion": "500MB Navegacion, LLamadas y SMS ilimitados, 1GB redes sociales, vigencia 13 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "100", "observacion": "1GB Navegacion, LLamadas y SMS ilimitados, redes sociales ilimitadas, vigencia 20 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "150", "observacion": "2GB Navegacion, LLamadas y SMS ilimitados, redes sociales ilimitadas, vigencia 26 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "200", "observacion": "3GB Navegacion, LLamadas y SMS ilimitados, redes sociales ilimitadas, vigencia 30 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "300", "observacion": "4GB Navegacion, LLamadas y SMS ilimitados, redes sociales ilimitadas, vigencia 33 dias" },
{ "Carrier_ID": "32", "Description": "Amigo sin Limite ", "Group": "TAE", "Monto": "500", "observacion": "6GB Navegacion, LLamadas y SMS ilimitados, redes sociales ilimitadas, vigencia 33 dias" },
{ "Carrier_ID": "33", "Description": "IZZI ", "Group": "SERVICIO", "Monto": "0", "observacion": "Atencion a clientes 01 800 120 5000" },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "20", "observacion": "Navegación 120MB, 200MB FB MSN y TW, WhatsApp ilimitado. Vigencia 1 día." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "30", "observacion": "Navegación 150MB, 300MB FB MSN y TW, WhatsApp ilimitado. Vigencia 3 días." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "50", "observacion": "Navegación 400MB, 500MB FB MSN, TW, SNAP e IG. WhatsApp ilimitado. Vigencia 7 días." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "80", "observacion": "" },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "100", "observacion": "Navegación 1GB, FB MSN, TW, SNAP, IG y WhatsApp ilimitado. Vigencia 15 días." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "150", "observacion": "Navegación 1.5GB, FB MSN, TW, SNAP, IG y WhatsApp ilimitado. Vigencia 28 días." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "200", "observacion": "Navegación 2GB, FB MSN, TW, SNAP, IG y WhatsApp ilimitado. Vigencia 30 días." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "300", "observacion": "Navegación 3.5GB, FB MSN, TW, SNAP, IG y WhatsApp ilimitado. Vigencia 33 días." },
{ "Carrier_ID": "35", "Description": "Internet Amigo", "Group": "TAE", "Monto": "500", "observacion": "Navegación 6.5GB, FB MSN, TW, SNAP, IG y WhatsApp ilimitado. Vigencia 33 días." },
{ "Carrier_ID": "39", "Description": "ATT FACTURA", "Group": "SERVICIO", "Monto": "0", "observacion": "" },
{ "Carrier_ID": "39", "Description": "ATT FACTURA", "Group": "SERVICIO", "Monto": "0", "observacion": "" },
{ "Carrier_ID": "69", "Description": "AVON", "Group": "SERVICIO", "Monto": "0", "observacion": "" }*/
