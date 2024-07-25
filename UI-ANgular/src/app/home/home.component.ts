import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { UrlCLientService } from '../url-client.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  url: string = environment.apiBaseUrl + "Url/AddUrl"
  urlData: UrlCLientService;
  isLoading: boolean = false;  // Loading flag
  constructor(private http: HttpClient ) {
    // Initialize the user instance
    this.urlData = new UrlCLientService();
  }
  onSubmit(): void {
    console.log(this.urlData.url);
    this.refreshList(this.urlData);
  }

  refreshList(data: UrlCLientService): void {
 
    this.isLoading = true;  // Set loading flag to true
    var config = {
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
      }
    };
    this.http.post(this.url, data)
      .subscribe({
        next: result => {
          this.urlData = result as UrlCLientService;
          this.isLoading = false;  // Reset loading flag in case of error
          console.log(result)
        },
        error:error=> {
          console.log(error)
        }
      })
  }
}
