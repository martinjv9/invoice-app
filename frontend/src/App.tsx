import { useEffect, useState } from "react";


function App() {

  const [backendStatus, setBackendStatus] = useState<string>("checking...");

  useEffect(() => {
    fetch("/api/health")
      .then((res) => res.json())
      .then((data) => setBackendStatus(`Connected - ${data.status}`))
      .catch(() => setBackendStatus("Not connected - is the backend running?"))
  }, []);

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center">
      <div className="text-center">
        <h1 className="text-4xl font-bold text-blue-600 mb-4">
          Invoice App
        </h1>
        <p className="text-gray-600 mb-2">
          Frontend is running on Vite + React
        </p>
        <p className={`text-sm font-medium ${backendStatus.includes("Connected") ? "text-green-600" : "text-red-500"}`}>
          Backend: {backendStatus}
        </p>
      </div>
    </div>
  );
}

export default App;