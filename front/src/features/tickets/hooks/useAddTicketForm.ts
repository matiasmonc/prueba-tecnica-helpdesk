import { useFormik } from "formik";
import * as yup from "yup";
import { addTicket } from "../../../api/tickets";
import Swal from "sweetalert2";

type AddTicketValues = {
    title: string;
    priority: "low" | "medium" | "high";
    description: string;
};

const ticketSchema = yup.object({
    title: yup
    .string()
    .trim()
    .required("El título es requerido")
    .min(5, "El título debe tener al menos 5 caracteres")
    .max(120, "El título no puede superar los 120 caracteres"),
  priority: yup
    .string()
    .oneOf(["low", "medium", "high"])
    .required("La prioridad es requerida"),
  description: yup
    .string()
    .trim()
    .required("La descripción es requerida")
    .min(10, "La descripción debe tener al menos 10 caracteres")
    .max(2000, "La descripción no puede superar los 2000 caracteres"),
});

export const useAddTicketForm = () => {
    return useFormik<AddTicketValues>({
        initialValues: {
            title: "",
            priority: "low",
            description: "",
        },
        validationSchema: ticketSchema,
        onSubmit: (values) => {
            console.log("Formulario enviado con valores:", values);
            addTicket({
                title: values.title,
                description: values.description,
                idPriority: values.priority === "low" ? 1 : values.priority === "medium" ? 2 : 3,
                idStatus: 1,
                createdBy: "9482257D-EBE7-4FA1-852F-494138A14D23"
            }).then((newTicket) => {
                console.log("Ticket creado:", newTicket);
                Swal.fire({
                    title: 'Ticket creado!',
                    text: 'El ticket ha sido creado exitosamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar',
                    confirmButtonColor: '#0077b6'
                })
            }).catch((error) => {
                console.error("Error al crear el ticket:", error);  
                Swal.fire({
                    title: 'Error!',
                    text: 'Hubo un error al crear el ticket',
                    icon: 'error',
                    confirmButtonText: 'Aceptar',
                    confirmButtonColor: '#0077b6'
                })
            });
        }
    });
}