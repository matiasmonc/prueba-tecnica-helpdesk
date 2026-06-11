import { usePageContext } from "./context/PageContext";
import { Layout } from "./features/Layout"
import { AddTicket } from "./features/tickets/pages/AddTicket";
import { Ticket } from "./features/tickets/pages/Ticket"

function App() {

  const {page} = usePageContext();

  return (
    <>
      <Layout children={
        <>
            {(page === "TICKET") && <Ticket />}
            {(page === "ADD_TICKET") && <AddTicket />}
          
        </>
      }/>
    </>
  )
}

export default App
