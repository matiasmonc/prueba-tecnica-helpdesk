export interface TicketParameters {
  status?: string;
  priority?: string;
  q?: string;
  page?: number;
  pageSize?: number;
}

export interface ITickets{
    tickets: ITicket[];
    totalFilteredRows: number;
    totalPages: number;
}

export interface ITicket {
    id: number;
    title: string;
    description: string;
    createdAt: Date;
    user: string;
    commentsCount: number;
    status: string;
    priority: string;
}

export interface ICreateTicket {
    title: string;
    description: string;
    idPriority: number;
    idStatus: number;
    createdBy: string;
}