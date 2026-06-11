type Props = {
  children: React.ReactNode
}

export const Layout = ({ children }: Props) => {
  return (
    <div className="min-h-screen grid grid-cols-[350px_1fr]">
        <div className="bg-[#0077b6] p-4">
            <h1 className="text-white text-2xl font-bold">Helpdesk</h1>
        </div>
        <div className="p-2">
            <div className="border border-gray-300 h-full rounded-xl shadow-md py-20">
                {children}
            </div>
        </div>
    </div>
  )
}
