/*App.jsx*/

import { useState, useEffect } from 'react';
import './App.css';
import TaskList from './TaskList';
import TaskForm from './TaskForm';

function App() {
    const [tasks, setTasks] = useState([]);
    const [currentTask, setCurrentTask] = useState(null);
    const [isExpanded, setIsExpanded] = useState(false);

    // Fetch tasks
    const fetchTasks = async () => {
        try {
            const res = await fetch('https://nobsbackend-cpf0bea5bxamcqfs.canadacentral-01.azurewebsites.net/api/Task');
            if (!res.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await res.json();
            console.log('Fetched tasks:', data);
            setTasks(data);
        } catch (error) {
            console.error('Error fetching tasks:', error);
        }
    };

    // Add a task
    const addTask = async (newTask) => {
        try {
            const res = await fetch('https://nobsbackend-cpf0bea5bxamcqfs.canadacentral-01.azurewebsites.net/api/Task', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newTask),
            });
            if (!res.ok) {
                throw new Error('Network response was not ok');
            }
            fetchTasks();
        } catch (error) {
            console.error('Error adding task:', error);
        }
    };

    // Delete a task
    const deleteTask = async (taskId) => {
        try {
            await fetch(`https://nobsbackend-cpf0bea5bxamcqfs.canadacentral-01.azurewebsites.net/api/Task/${taskId}`, {
                method: 'DELETE',
            });
            fetchTasks();
        } catch (error) {
            console.error('Error deleting task:', error);
        }
    };

    //Update tasks
    const updateTask = async (updatedTask) => {
        try {
            const res = await fetch(`https://nobsbackend-cpf0bea5bxamcqfs.canadacentral-01.azurewebsites.net/api/Task/${updatedTask.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedTask),
            });
            if (!res.ok) {
                throw new Error('Network response was not ok');
            }
            fetchTasks();
            setCurrentTask(null);
        } catch (error) {
            console.error('Error updating task:', error);
        }
    };

    // Helper function to upateTaks
    const handleTaskUpdate = (task) => {
        setCurrentTask(task);
    };

    // Toggle tasks visibility
    const toggleTasks = () => {
        if (isExpanded) {
            setTasks([]);
        } else {
            fetchTasks();
        }
        setIsExpanded(!isExpanded);
    };

    return (
        <div>
            <h1>No BS Planner</h1>
            <TaskForm onSubmit={currentTask ? updateTask : addTask} currentTask={currentTask} />
            <button onClick={toggleTasks}>{isExpanded ? 'Minimize Tasks' : 'Expand Tasks'}</button>
            <div className="container">
                <TaskList tasks={tasks} onDelete={deleteTask} onUpdate={handleTaskUpdate} />
            </div>
        </div>
    );
}

export default App;