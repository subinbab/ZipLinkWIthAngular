import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';  // <-- Import FormsModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { DataDisplayComponent } from './data-display/data-display.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DataDisplayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule  // <-- Add FormsModule to imports array
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
