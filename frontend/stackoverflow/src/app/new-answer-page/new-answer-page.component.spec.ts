import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewAnswerPageComponent } from './new-answer-page.component';

describe('NewAnswerPageComponent', () => {
  let component: NewAnswerPageComponent;
  let fixture: ComponentFixture<NewAnswerPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewAnswerPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewAnswerPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
