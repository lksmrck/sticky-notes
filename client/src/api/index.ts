import { NoteType } from "../types"

const URL = "https://localhost:7280/api/NoteAPI/"

export const getNotes = async (): Promise<NoteType[]> => {
    const res = await fetch(URL)
    const data = await res.json()
    return data.result
}

export const getNote = () => {
    
}

export const createNote = async (note: NoteType) => {
    const res = await fetch(URL, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(note)
    })

    const data = await res.json()
    return data.result
}

export const deleteNote = async (id: number) => {
    const res = await fetch(URL+id, {
        method: "DELETE",
        headers: {"Content-Type": "application/json"},
       
    })
    
}