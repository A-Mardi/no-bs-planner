import { useState, useEffect } from 'react';
import './App.css';
import TaskList from './TaskList'; // Ensure you have this import
import TaskForm from './TaskForm'; // Make sure to import your TaskForm

function App() {
    const [tasks, setTasks] = useState([]);
    const [currentTask, setCurrentTask] = useState(null); // For editing a task

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
            fetchTasks(); // Refresh tasks after adding
        } catch (error) {
            console.error('Error adding task:', error);
        }
    };

    const deleteTask = async (taskId) => {
        try {
            await fetch(`https://nobsbackend-cpf0bea5bxamcqfs.canadacentral-01.azurewebsites.net/api/Task/${taskId}`, {
                method: 'DELETE',
            });
            fetchTasks(); // Refresh tasks after deletion
        } catch (error) {
            console.error('Error deleting task:', error);
        }
    };

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
            fetchTasks(); // Refresh tasks after updating
            setCurrentTask(null); // Reset current task after updating
        } catch (error) {
            console.error('Error updating task:', error);
        }
    };

    const handleTaskUpdate = (task) => {
        setCurrentTask(task);
    };

    return (
        <div>
            <h1>No BS Planner</h1>
            <TaskForm onSubmit={currentTask ? updateTask : addTask} currentTask={currentTask} />
            <button onClick={fetchTasks}>Expand Tasks</button> {/* Button to fetch tasks */}
            <div className="container">
                <TaskList tasks={tasks} onDelete={deleteTask} onUpdate={handleTaskUpdate} />
            </div>
        </div>
    );
}

export default App;
