import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule],
  templateUrl: './student.html'
})
export class StudentComponent {

  // One-way binding
  title = 'Student Management App';

  // Two-way binding
  studentName = '';

  // Student list for ngFor
  students: string[] = [];

  // Reactive Form
  studentForm = new FormGroup({
    name: new FormControl('', Validators.required)
  });

  // Loader + Fake token for "advanced features"
  isLoading = false;
  fakeToken = 'Bearer faketoken123';

  constructor(private http: HttpClient) {}

  // Add student from input box
  addStudent() {
    if (this.studentName) {
      this.students.push(this.studentName);
      this.studentName = '';
    } else {
      alert('Please enter a student name');
    }
  }

  // Load students from fake API (GET request)
  loadStudents() {
    this.isLoading = true; // Show loader

    this.http.get<any[]>('https://jsonplaceholder.typicode.com/users', {
      headers: { Authorization: this.fakeToken } // attach fake token
    }).subscribe({
      next: data => {
        this.students = data.map(d => d.name); // Store student names
        console.log('API response:', data);    // Log response
        this.isLoading = false;                // Hide loader
      },
      error: err => {
        alert('Global API Error: ' + err.message); // Global error
        this.isLoading = false;                    // Hide loader
      }
    });
  }
}
