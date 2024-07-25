
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-data-display',
  templateUrl: './data-display.component.html',
  styleUrl: './data-display.component.css'
})
export class DataDisplayComponent implements OnInit {
  data: string | null = null;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.data = params.get('data'); // Get the 'data' parameter from the URL
    });
  }
}
