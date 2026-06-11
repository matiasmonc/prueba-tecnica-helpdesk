import type { ITicket } from "../interfaces/ITicket"
import { TicketItem } from "./TicketItem"

type Props = {
    tickets?: ITicket[]
}

export const TicketContent = ({ tickets }: Props) => {
  return (
    <div className="h-[max_content]">
        <div className="grid grid-cols-[100px_250px_1fr_repeat(3,200px)] font-bold text-gray-800 border-b border-t border-gray-300 shadow-sm p-4 h-12 items-center">
            <div>ID</div>
            <div>Título</div>
            <div>Descripción</div>
            <div>Prioridad</div>
            <div>Status</div>
            <div>Creador</div>
        </div>
        <div>
            {tickets?.map((ticket) => (
                <TicketItem key={ticket.id} ticket={ticket} />
            ))}
        </div>
    </div>
  )
}
