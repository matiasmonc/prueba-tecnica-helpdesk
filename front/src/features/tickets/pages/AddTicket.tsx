import { usePageContext } from "../../../context/PageContext";
import { useAddTicketForm } from "../hooks/useAddTicketForm";

export const AddTicket = () => {

    const formik = useAddTicketForm();
    const { setPage } = usePageContext();

  return (
    <div className="px-10">
        <p className="text-blue-500 underline cursor-pointer w-max" onClick={() => setPage("TICKET")}>
            Ir a Tickets
        </p>
        <h1 className="text-2xl font-bold text-center mb-10">Crear Ticket</h1>

        <form onSubmit={formik.handleSubmit} className="grid grid-cols-1 gap-4 mt-4">
            <div className="grid grid-cols-[65%_1fr] gap-10 mb-5">
                <div className="flex flex-col">
                    <label htmlFor="title" className="font-semibold mb-1">Título</label>
                    <input
                        type="text"
                        id="title"
                        className="border border-gray-300 rounded-md p-2"
                        {...formik.getFieldProps("title")}
                    />
                    {formik.touched.title && formik.errors.title ? (
                        <div className="text-red-500 text-sm mt-1">{formik.errors.title}</div>
                    ) : null}
                </div>
                <div className="flex flex-col">
                    <label htmlFor="priority" className="font-semibold mb-1">Prioridad</label>
                    <select
                        id="priority"
                        className="border border-gray-300 rounded-md p-2"
                        {...formik.getFieldProps("priority")}
                    >
                        <option value="low">Baja</option>
                        <option value="medium">Media</option>
                        <option value="high">Alta</option>
                    </select>   
                    {formik.touched.priority && formik.errors.priority ? (
                        <div className="text-red-500 text-sm mt-1">{formik.errors.priority}</div>
                    ) : null}
                </div>        
            </div>
            <div className="flex flex-col">
                <label htmlFor="description" className="font-semibold mb-1">Descripción</label>
                <textarea
                    id="description"
                    className="border border-gray-300 rounded-md p-2"
                    rows={4}
                    {...formik.getFieldProps("description")}
                />    
                {formik.touched.description && formik.errors.description ? (
                    <div className="text-red-500 text-sm mt-1">{formik.errors.description}</div>
                ) : null}
            </div>  
            
            <button type="submit" className="bg-[#0077b6] text-white px-4 py-2 rounded-md h-15 text-lg mt-10">Crear Ticket</button>
        </form>


    </div>
  )
}
