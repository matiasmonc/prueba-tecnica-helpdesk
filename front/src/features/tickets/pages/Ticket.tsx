import { useEffect, useState } from "react";
import { TicketContent } from "../components/TicketContent"
import { getTickets } from "../../../api/tickets";    
import type { ITickets } from "../interfaces/ITicket";
import { MoveLeftIcon, MoveRightIcon } from "lucide-react";
import { usePageContext } from "../../../context/PageContext";

export const Ticket = () => {

    const { setPage } = usePageContext();

    const [tickets, setTickets] = useState<ITickets>();

    useEffect(() => {
        getTickets()
            .then(data => setTickets(data))
            .catch(() => setTickets(undefined)); 
    },[])   

    useEffect(() => {
        console.log(tickets);
    }, [tickets])

  return (
    <>
        <div className="grid grid-rows-[auto_1fr] items-center justify-center mb-10">
            <h1 className="text-2xl font-bold text-center">Mesa de ayuda</h1>
        </div>
        <div className="h-4 grid grid-flow-col items-center justify-between p-4 mb-10 px-10">
            <h2 className="text-xl font-semibold">Gestión de Tickets</h2>
            <button className="bg-[#0077b6] text-white px-4 py-2 rounded-md cursor-pointer" onClick={() => setPage("ADD_TICKET")}>
                Crear Ticket
            </button>
        </div>
        <TicketContent tickets={tickets?.tickets || []} />
        <div className="h-10 grid grid-flow-col items-start justify-between mt-4 px-10">
            <span className="text-gray-600 ">{tickets?.totalFilteredRows || 0} tickets</span>
            <div className="h-full flex items-center">
                <div className="p-2 border border-[#0077b6] rounded-l-md h-full flex items-center"><MoveLeftIcon size={15} color="#0077b6" /></div>
                <div className="border border-[#0077b6] h-full">
                    {
                        tickets?.totalPages ? (
                            Array.from({ length: tickets.totalPages }, (_, i) => i + 1).map((page) => (
                                <button key={page} className="px-3 py-1 bg-[#0077b6] text-white h-full">{page}</button>
                            ))
                        ) : null
                    }
                </div>
                <div className="p-2 border border-[#0077b6] rounded-r-md h-full flex items-center"><MoveRightIcon size={15} color="#0077b6" /></div>
            </div>
        </div>
    </>
  )
}
