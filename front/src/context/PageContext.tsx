import { createContext, useContext, useState, type ReactNode } from "react";

export type PageName = "TICKET" | "ADD_TICKET";

export interface IPageContext {
    page: PageName;
    setPage: (page: PageName) => void;
}

const PageContext = createContext<IPageContext | undefined>(undefined);

export const PageProvider = ({ children }: { children: ReactNode }) => {
    const [page, setPage] = useState<PageName>("TICKET");

    return (
        <PageContext.Provider value={{ page, setPage }}>
            {children}
        </PageContext.Provider>
    );
}

export const usePageContext = () => {
    const context = useContext(PageContext);

    if (!context) {
        throw new Error("usePageContext must be used within a PageProvider");
    }
    return context;
};