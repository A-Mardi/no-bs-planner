// src/App.jsx
import { useState, useEffect } from 'react';
import API_BASE_URL from './config';
import TaskList from './TaskList';
import TaskFilter from './TaskFilter';
import TaskForm from './TaskForm';
import './App.css';

function App() {
    const [tasks, setTasks] = useState([]);
    const [currentTask, setCurrentTask] = useState(null);
    const [filter, setFilter] = useState('all');

    useEffect(() => {
        fetchTasks();
    }, []);

    const fetchTasks = async () => {
        try {
            const res = await fetch(`${API_BASE_URL}/api/Task`);
            const data = await res.json();
            setTasks(data);
        } catch (error) {
            console.error('Error fetching tasks:', error);
        }
    };

    const addTask = async (task) => {
        try {
            const res = await fetch(`${API_BASE_URL}/api/Task`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(task),
            });
            if (res.ok) {
                fetchTasks(); // Refresh the list after adding
            }
        } catch (error) {
            console.error('Error adding task:', error);
        }
    };

    const deleteTask = async (id) => {
        try {
            await fetch(`${API_BASE_URL}/api/Task/${id}`, {
                method: 'DELETE',
            });
            fetchTasks(); // Refresh the list after deletion
        } catch (error) {
            console.error('Error deleting task:', error);
        }
    };

    const updateTask = async (task) => {
        try {
            const res = await fetch(`${API_BASE_URL}/api/Task/${currentTask.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(task),
            });
            if (res.ok) {
                fetchTasks(); // Refresh the list after updating
                setCurrentTask(null); // Reset current task
            }
        } catch (error) {
            console.error('Error updating task:', error);
        }
    };

    const filterTasks = () => {
        if (filter === 'completed') {
            return tasks.filter((task) => task.completed);
        } else if (filter === 'notCompleted') {
            return tasks.filter((task) => !task.completed);
        }
        return tasks;
    };

    return (
        <div>
            <h1>No BS Planner</h1>
            <div className ="container">
                <TaskFilter onFilterChange={setFilter} />
                <TaskForm onSubmit={currentTask ? updateTask : addTask} currentTask={currentTask} />
                <TaskList tasks={filterTasks()} onDelete={deleteTask} onUpdate={setCurrentTask} />
            </div>
        </div>
    );
}

export default App;
