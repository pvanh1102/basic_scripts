using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
    #region Fields

    // timer duration// độ dài của thời gian được đếm ngược (duration) tính bằng giây.
    float totalSeconds = 0;
	
	// timer execution
	float elapsedSeconds = 0; //lưu trữ thời gian đã trôi qua tính bằng giây kể từ khi bắt đầu chạy đồng hồ.

    bool running = false; // check xem đồng hồ có đang chạy hay không
	
	// support for Finished property
	bool started = false; // check xem đồng hồ đã được bắt đầu hay chưa
	
	#endregion
	
	#region Properties
	
	/// <summary>
	/// Sets the duration of the timer
	/// The duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
    {
		set
        {
			if (!running) // cho phép thiết lập độ dài của đồng hồ
            {
				totalSeconds = value;
			}
		}
	}
	
	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
    {
		get { return started && !running; } // kiểm tra xem đồng hồ đã kết thúc chạy hay chưa. Trả về true nếu đã kết thúc và đã được bắt đầu 
    }
	
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
		get { return running; }// Kiểm tra xem đồng hồ có đang chạy hay không
	}

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {	
		// update timer and check for finished
		if (running)
        {
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
			}
		}
	}
	
	/// <summary>
	/// Runs the timer
	/// Because a timer of 0 duration doesn't really make sense,
	/// the timer only runs if the total seconds is larger than 0
	/// This also makes sure the consumer of the class has actually 
	/// set the duration to something higher than 0
	/// </summary>
	public void Run()
    {	
		// only run with valid duration
		// ngoài việc thiết lập thời gian đếm ngược lớn hơn 0 ra thì nó còn thiết lập các thông số khác để bắt đầu quá trình đếm ngược nữa

		if (totalSeconds > 0)
        {
			started = true;
			running = true;
            elapsedSeconds = 0;
		}
	}
	
	#endregion
}
