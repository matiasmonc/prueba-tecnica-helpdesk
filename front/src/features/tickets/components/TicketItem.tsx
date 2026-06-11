import type { ITicket } from "../interfaces/ITicket"

type Props = {
    ticket: ITicket
}

export const TicketItem = ({ ticket }: Props) => {
  return (
    <div className="border-b border-gray-300 p-4 grid grid-cols-[100px_250px_1fr_repeat(3,200px)] h-15 hover:bg-[#caf0f8] items-center content-center">
        <div className="p-2">{ticket.id}</div>
        <div className="p-2 truncate text-[#0077b6] underline cursor-pointer">{ticket.title}</div>
        <div className="p-2 truncate">{ticket.description}</div>
        <div className="p-2">
            <div className="border py-1 rounded-2xl w-[80%] text-center">{ticket.priority}</div>
        </div>
        <div className="p-2">{ticket.status}</div>
        <div className="p-2">{ticket.user}</div>
    </div>
  )
}