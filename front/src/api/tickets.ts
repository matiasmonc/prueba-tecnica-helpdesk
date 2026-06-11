import type { ICreateTicket, ITicket, ITickets, TicketParameters } from "../features/tickets/interfaces/ITicket";

const urlApi = 'https://localhost:7019/api';

export const getTickets = async (parameters?: TicketParameters): Promise<ITickets> => {
    try{
      const queryParams = new URLSearchParams({
        status: parameters?.status || '',
        priority: parameters?.priority || '',
        q: parameters?.q || '',
        page: parameters?.page ? String(parameters.page) : '1',
        pageSize: parameters?.pageSize ? String(parameters.pageSize) : '5',
      });
      
      const url = `${urlApi}/tickets?${queryParams.toString()}`;
      
      const res = await fetch(url,{
          mode: 'cors',
          method: 'GET',
          headers:{
              'Accept': 'application/json',
              'Content-Type': 'application/json',
          }
      });
  
      const data = await res.json();
      return data;
          
      }catch(e){
          throw e;
      }
  }


  export const addTicket = async (parameters: ICreateTicket): Promise<ITicket> => {
    try{
      
      const url = `${urlApi}/tickets`;
      
      const res = await fetch(url,{
          mode: 'cors',
          method: 'POST',
          headers:{
              'Accept': 'application/json',
              'Content-Type': 'application/json',
          },
          body: JSON.stringify(parameters)
      });
  
      const data = await res.json();
      return data;
          
      }catch(e){
          throw e;
      }
  }