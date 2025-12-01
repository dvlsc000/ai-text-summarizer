import React, { useState } from "react";
import "./App.css";

function App() {
  const [inputText, setInputText] = useState("");
  const [summary, setSummary] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const handleSummarize = async () => {
    setError("");
    setSummary("");

    if (!inputText.trim()) {
      setError("Please enter some text to summarize.");
      return;
    }

    setLoading(true);

    try {
      const response = await fetch("https://localhost:5125/summarize", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ text: inputText }),
      });

      if (!response.ok) {
        const msg = await response.text();
        throw new Error(msg || "Failed to summarize.");
      }

      const data = await response.json();
      setSummary(data.summary);
    } catch (err) {
      console.error(err);
      setError(err.message || "Something went wrong.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="app">
      <h1>AI Text Summarizer</h1>
      <p className="subtitle">
        Paste some text below and click <strong>Summarize</strong>.
      </p>

      <textarea
        value={inputText}
        onChange={(e) => setInputText(e.target.value)}
        placeholder="Paste your article, essay, or any long text here..."
      />

      <button onClick={handleSummarize} disabled={loading}>
        {loading ? "Summarizing..." : "Summarize"}
      </button>

      {error && <div className="error">{error}</div>}

      {summary && (
        <div className="summary-box">
          <h2>Summary</h2>
          <p>{summary}</p>
        </div>
      )}
    </div>
  );
}

export default App;
